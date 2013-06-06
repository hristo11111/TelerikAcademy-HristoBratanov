using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static long maxSum;
    static HashSet<Node> visited = new HashSet<Node>();

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        Dictionary<long, Node> nodes = new Dictionary<long, Node>();

        for (int i = 0; i < N - 1; i++)
        {
            string input = Console.ReadLine();
            string[] nums = input.Split(new char[] { '(', ')', '-', '<' }, StringSplitOptions.RemoveEmptyEntries);

            long parent = long.Parse(nums[0]);
            long child = long.Parse(nums[1]);

            Node parentNode;

            if (nodes.ContainsKey(parent))
            {
                parentNode = nodes[parent];
            }
            else
            {
                parentNode = new Node(parent);
                nodes.Add(parent, parentNode);
            }

            Node childNode;
            if (nodes.ContainsKey(child))
            {
                childNode = nodes[child];
            }
            else
            {
                childNode = new Node(child);
                nodes.Add(child, childNode);
            }

            parentNode.AddChild(childNode);
            childNode.AddChild(parentNode);
        }

        foreach (var pair in nodes)
        {
            if (pair.Value.ChildrenCount == 1)
            {
                visited.Clear();
                DFS(pair.Value, 0);
            }
        }

        Console.WriteLine(maxSum);
    }

    static void DFS(Node node, long currentSum)
    {
        currentSum = currentSum + node.Value;
        visited.Add(node);

        for (int i = 0; i < node.ChildrenCount; i++)
        {
            if (visited.Contains(node.Children[i]))
            {
                continue;
            }
            
            DFS(node.Children[i], currentSum);
        }

        if (node.ChildrenCount == 1 && currentSum > maxSum)
        {
            maxSum = currentSum;
        }
    }
}

public class Node
{
    private long value;
    private List<Node> children;

    public Node(long value)
    {
        this.value = value;
        this.children = new List<Node>();
    }

    public void AddChild(Node child)
    {
        this.children.Add(child);
    }

    public long Value
    {
        get { return this.value; }
    }

    public List<Node> Children
    {
        get { return this.children; }
    }

    public int ChildrenCount
    {
        get { return this.children.Count; }
    }
}
