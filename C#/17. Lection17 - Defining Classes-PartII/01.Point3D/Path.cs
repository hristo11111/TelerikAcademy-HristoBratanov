using System;
using System.Collections.Generic;

public class Path
{
    private List<Point3D> sequenceOfPoint = new List<Point3D>();
    public List<Point3D> SequenceOfPoint
    {
        get
        {
            return this.sequenceOfPoint;
        }
        set
        {
            this.sequenceOfPoint = value;
        }
    }

    public Path()
    {
    }


    public void AddPointToSequence(Point3D point)
    {
        this.sequenceOfPoint.Add(point);
    }   
    
}
