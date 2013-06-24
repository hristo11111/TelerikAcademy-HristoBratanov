using System;
using System.Collections.Generic;

// problem "Приятелите на Пешо" http://bgcoder.com/Contest/Practice/27 100/100

class PeshoFriends
{
    static void Main()
    {
        string[] firstInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int points = int.Parse(firstInput[0]);
        int streets = int.Parse(firstInput[1]);
        int hospitals = int.Parse(firstInput[2]);
        int houses = points - hospitals;


        Dictionary<Point, List<Street>> map = new Dictionary<Point, List<Street>>();
        Point[] allPoints = new Point[60000];

        List<Point> hospitalPoints = new List<Point>();
        string[] secondInput = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < secondInput.Length; i++)
		{
            Point hospital = new Point(int.Parse(secondInput[i]));
            hospital.isHospital = true;
		    hospitalPoints.Add(hospital);
            allPoints[int.Parse(secondInput[i])] = hospital;
            map.Add(hospital, new List<Street>());
		}
        
        for (int i = 0; i < streets; i++)
        {
            string[] streetData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int house1Index = int.Parse(streetData[0]);
            Point house1 = new Point(house1Index);
            if (allPoints[house1Index] != null)
            {
                house1 = allPoints[house1Index];
            }
            else
            {
                allPoints[house1Index] = house1;
                map.Add(house1, new List<Street>());
            }

            int house2Index = int.Parse(streetData[1]);
            Point house2 = new Point(house2Index);
            if (allPoints[house2Index] != null)
            {
                house2 = allPoints[house2Index];
            }
            else
            {
                allPoints[house2Index] = house2;
                map.Add(house2, new List<Street>());
            }

            map[house1].Add(new Street(house2, int.Parse(streetData[2])));
            map[house2].Add(new Street(house1, int.Parse(streetData[2])));
        }

        List<double> possibleDistances = new List<double>();

        for (int i = 0; i < hospitalPoints.Count; i++)
        {
            Point hospital = hospitalPoints[i];
            FindBestWays(map, hospital, allPoints);

            double distance = 0;

            foreach (var item in allPoints)
            {
                if (item != null && item.isHospital == false)
                {
                    distance += item.BestDistance;
                }
            }

            possibleDistances.Add(distance);
        }

        possibleDistances.Sort();

        Console.WriteLine(possibleDistances[0]);
    }


    private static void FindBestWays(Dictionary<Point, List<Street>> map, Point hospital, Point[] allPoints)
    {
        PriorityQueue<Point> queue = new PriorityQueue<Point>();

        foreach (var item in map)
        {
            if (hospital.ID != item.Key.ID)
            {
                item.Key.BestDistance = double.PositiveInfinity;
            }
        }

        hospital.BestDistance = 0.0d;
        queue.Enqueue(hospital);

        while (queue.Count != 0)
        {
            Point currentPoint = queue.Dequeue();

            if (currentPoint.BestDistance == double.PositiveInfinity)
            {
                break;
            }

            foreach (var neighbour in map[currentPoint])
            {
                double potDistance = currentPoint.BestDistance + neighbour.Distance;

                if (potDistance < neighbour.Point.BestDistance)
                {
                    neighbour.Point.BestDistance = potDistance;
                    queue.Enqueue(neighbour.Point);
                }
            }
        }
    }    
}

public class Point : IComparable
{
    public int ID { get; private set; }
    public double BestDistance { get; set; }
    public bool isHospital { get; set; }

    public Point(int ID)
    {
        this.ID = ID;
    }

    public int CompareTo(object obj)
    {
        return this.BestDistance.CompareTo((obj as Point).BestDistance);
    }

    public override bool Equals(object obj)
    {
        return this.ID == (obj as Point).ID;
    }

    public override int GetHashCode()
    {
        return (int)this.ID;
    }
}

public class Street
{
    public int Distance { get; set; }
    public Point Point { get; set; }

    public Street(Point point, int distance)
    {
        this.Point = point;
        this.Distance = distance;
    }
}

public class PriorityQueue<T> where T : IComparable
{
    private T[] heap;
    private int index;

    public int Count
    {
        get
        {
            return this.index - 1;
        }
    }

    public PriorityQueue()
    {
        this.heap = new T[16];
        this.index = 1;
    }

    public void Enqueue(T element)
    {
        if (this.index >= this.heap.Length)
        {
            IncreaseArray();
        }

        this.heap[this.index] = element;

        int childIndex = this.index;
        int parentIndex = childIndex / 2;
        this.index++;

        while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
        {
            T swapValue = this.heap[parentIndex];
            this.heap[parentIndex] = this.heap[childIndex];
            this.heap[childIndex] = swapValue;

            childIndex = parentIndex;
            parentIndex = childIndex / 2;
        }
    }

    public T Dequeue()
    {
        T result = this.heap[1];

        this.heap[1] = this.heap[this.Count];
        this.index--;

        int rootIndex = 1;

        int minChild;

        while (true)
        {
            int leftChildIndex = rootIndex * 2;
            int rightChildIndex = rootIndex * 2 + 1;

            if (leftChildIndex > this.index)
            {
                break;
            }
            else if (rightChildIndex > this.index)
            {
                minChild = leftChildIndex;
            }
            else
            {
                if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    minChild = rightChildIndex;
                }
            }

            if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
            {
                T swapValue = this.heap[rootIndex];
                this.heap[rootIndex] = this.heap[minChild];
                this.heap[minChild] = swapValue;

                rootIndex = minChild;
            }
            else
            {
                break;
            }
        }

        return result;
    }

    public T Peek()
    {
        return this.heap[1];
    }

    private void IncreaseArray()
    {
        T[] copiedHeap = new T[this.heap.Length * 2];

        for (int i = 0; i < this.heap.Length; i++)
        {
            copiedHeap[i] = this.heap[i];
        }

        this.heap = copiedHeap;
    }
}
