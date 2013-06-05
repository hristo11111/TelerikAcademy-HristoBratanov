using System;
using System.Linq;

//The traversial is slow, so please wait when execute!
class DemoFolderTree
{
    static void Main()
    {
        string path = @"C:\Windows";

        FolderTree windowsTree = new FolderTree(path);
        windowsTree = windowsTree.TreeDFS();

        Folder appPatch = windowsTree.FindFolder(@"C:\Windows\AppPatch");
        double sum = appPatch.CalculateFileSizeSum(appPatch) / 1048576;

        Console.WriteLine(@"sum of files in C:\Windows\AppPatch = {0:0.00}mb", sum);
    }
}
