﻿using System;
using System.Linq;
using System.IO;
using System.Xml.Linq;


class Program
{
    static void Main()
    {
        string startDirectory = @"C:\temp";

        XElement booksXml = new XElement("directories",
            CreateXMLForDirectory(startDirectory)
        );

        booksXml.Save("../../directories.xml");
    }

    public static XElement CreateXMLForDirectory(string sourceDirectory)
    {
        try
        {
            FileInfo fileInfoSource = new FileInfo(sourceDirectory);

            XElement roothDirectory = new XElement("directory",
            new XAttribute("name", fileInfoSource.Name));

            var files = Directory.EnumerateFiles(sourceDirectory);
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                roothDirectory.Add(new XElement("file"),
                    new XElement("name", fileInfo.Name),
                    new XElement("type", fileInfo.Extension)
                    );

            }

            var directories = Directory.EnumerateDirectories(sourceDirectory);
            foreach (var directory in directories)
            {

                roothDirectory.Add(CreateXMLForDirectory(directory));

            }

            return roothDirectory;
        }
        catch (Exception e)
        {

            throw new ArgumentException("Error" + e.Message);
        }
    }
}
