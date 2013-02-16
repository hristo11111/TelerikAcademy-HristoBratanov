using System;

class CheckFilePathAndReadPrint
{
    static void Main()
    {
        string path = Console.ReadLine();
        try
        {
            Console.WriteLine(System.IO.File.ReadAllText(path));
        }

        catch (ArgumentNullException)
        {
            Console.WriteLine("Path is null");
        }
        catch (System.IO.PathTooLongException)
        {
            Console.WriteLine("The specified path, file name, or both exceed the system-defined maximum length. For example, on Windows-based platforms, paths must be less than 248 characters, and file names must be less than 260 characters");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Path is a zero-length string, contains only white space, or contains one or more invalid characters");
        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Console.WriteLine("The specified path is invalid (for example, it is on an unmapped drive)");
        }

        catch (System.IO.FileNotFoundException)
        {
            Console.WriteLine("The file specified in path was not found");
        }

        catch (System.IO.IOException)
        {
            Console.WriteLine("An I/O error occurred while opening the file");
        }

        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("path specified a file that is read-only");
            Console.WriteLine("-or-");
            Console.WriteLine("This operation is not supported on the current platform");
            Console.WriteLine("-or-");
            Console.WriteLine("path specified a directory");
            Console.WriteLine("-or-");
            Console.WriteLine("The caller does not have the required permission");
        }

        catch (System.NotSupportedException)
        {
            Console.WriteLine("path is in an invalid format");
        }

        catch (System.SystemException)
        {
            Console.WriteLine("The caller does not have the required permission");
        }
        
    }

}
