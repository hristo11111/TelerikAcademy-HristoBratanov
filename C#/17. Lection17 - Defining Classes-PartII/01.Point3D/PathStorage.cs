using System;
using System.Collections.Generic;
using System.IO;

static class PathStorage
{
    static public List<Path> PathLoad()
    {
        string line;
        Path sequence = new Path();
        List<Path> paths = new List<Path>();
        Point3D point = new Point3D();
        StreamReader reader = new StreamReader(@".../.../loadpath.txt");
        using (reader)
        {
            while ((line = reader.ReadLine()) != null)
            {
                if (line != "-")
                {
                    string[] chars = line.Split(',');
                    point.X = double.Parse(chars[0]);
                    point.Y = double.Parse(chars[1]);
                    point.Z = double.Parse(chars[2]);
                    sequence.AddPointToSequence(point);
                }
                else
                {
                    paths.Add(sequence);
                }
            }
            return paths;
        }
    }

    static public void PathSave(Path path)
    {
        StreamWriter writer = new StreamWriter(@".../.../savepath.txt");
        using (writer)
        {
            foreach (var item in path.SequenceOfPoint)
            {
                writer.WriteLine(item);
            }
        }
    }
}
