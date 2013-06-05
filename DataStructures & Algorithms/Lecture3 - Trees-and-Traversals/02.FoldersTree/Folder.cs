using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



class Folder
{
    private string name;
    private List<Folder> childFolders;
    private List<File> files;

    public Folder(string name)
    {
        this.name = name;
        this.childFolders = new List<Folder>();
        this.files = new List<File>();
    }

    public void AddFolder(Folder folder)
    {
        if (folder == null)
        {
            throw new ArgumentNullException("Folder cannot be null!");
        }

        this.childFolders.Add(folder);
    }

    public void AddFile(File file)
    {
        if (file == null)
        {
            throw new ArgumentNullException("File cannot be null!");
        }

        this.files.Add(file);
    }

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public List<Folder> ChildFolders
    {
        get { return this.childFolders; }
    }

    public List<File> Files
    {
        get { return this.files; }
    }

    public int FilesCount()
    {
        return this.files.Count;
    }

    public int FoldersCount()
    {
        return this.childFolders.Count();
    }

    public File GetFile(int index)
    {
        return this.files[index];
    }

    public Folder GetFolder(int index)
    {
        return this.childFolders[index];
    }

    public Folder FindFolder(string folderName)
    {
        foreach (Folder folder in this.ChildFolders)
        {
            if (folder.Name == folderName)
            {
                return folder;
            }

            Folder result = folder.FindFolder(folderName);
            if (result != null)
            {
                return result;
            }
        }
        return null;
    }

    public double CalculateFileSizeSum(Folder folder)
    {
        double sum = 0;
        foreach (var file in folder.Files)
        {
            sum += file.Size;
        }
        foreach (var subFolder in folder.childFolders)
        {
            CalculateFileSizeSum(subFolder);
        }

        return sum;
    }
}
