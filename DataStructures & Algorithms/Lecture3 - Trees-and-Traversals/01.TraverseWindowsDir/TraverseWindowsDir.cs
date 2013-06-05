using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class TraverseWindowsDir
{
    static void Main(string[] args)
    {
        string searchPath = @"C:\Windows";

        DirectoryDFS(searchPath);
    }

    public static void DirectoryDFS(string path)
    {
        Stack<string> foldersStack = new Stack<string>();

        foldersStack.Push(path);

        try
        {
            while (foldersStack.Count > 0)
            {
                var folderToSearch = foldersStack.Pop();
                var exeFiles = Directory.GetFiles(folderToSearch, "*.exe");
                for (int i = 0; i < exeFiles.Length; i++)
                {
                    Console.WriteLine(exeFiles[i]);
                }

                var currentFolders = Directory.GetDirectories(path);
                foreach (var directory in currentFolders)
                {
                    DirectoryDFS(directory);
                }
            }

        }

        //catches the exceptions if access restricted folder reached
        catch (UnauthorizedAccessException)
        {
        }

    }
}
