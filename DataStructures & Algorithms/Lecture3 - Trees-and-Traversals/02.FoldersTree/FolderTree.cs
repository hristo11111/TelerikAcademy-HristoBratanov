using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

class FolderTree
{
    private Folder mainFolder;

    public FolderTree(string name)
    {
        this.mainFolder = new Folder(name);
    }

    public FolderTree(string name, File[] files, Folder[] folders)
        : this(name)
    {
        foreach (var folder in folders)
        {
            this.mainFolder.AddFolder(folder);
        }

        foreach (var file in files)
        {
            this.mainFolder.AddFile(file);
        }
    }

    public Folder MainFolder
    {
        get { return this.mainFolder; }
    }

    private Folder DirectoryDFS(Folder folder)
    {
        try
        {
            var files = Directory.GetFiles(folder.Name);
            foreach (string item in files)
            {
                FileInfo fileinfo = new FileInfo(item);
                File file = new File(item, (int)fileinfo.Length);
                folder.AddFile(file);
            }

            var childFolders = Directory.GetDirectories(folder.Name);
            foreach (string item in childFolders)
            {
                Folder subFolder = new Folder(item);
                folder.AddFolder(subFolder);
                DirectoryDFS(subFolder);
            }
        }

        //catches the exceptions given if access restricted folder reached
        catch (UnauthorizedAccessException)
        {
        }

        return folder;
    }

    public FolderTree TreeDFS()
    {
        Folder f = (DirectoryDFS(mainFolder));
        FolderTree tree = new FolderTree(f.Name, f.Files.ToArray(), f.ChildFolders.ToArray());

        return tree;
    }

    public Folder FindFolder(string folderName)
    {
        return this.mainFolder.FindFolder(folderName);
    }
}
