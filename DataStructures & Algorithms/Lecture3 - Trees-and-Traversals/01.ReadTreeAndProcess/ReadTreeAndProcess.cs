using System;
using System.Collections.Generic;
using System.Linq;

class ReadTreeAndProcess
{
    static int count;
    static List<TreeNode<int>> path = new List<TreeNode<int>>();
    static List<List<TreeNode<int>>> allPaths = new List<List<TreeNode<int>>>();

    
    static void Main()
    {
        int nodesCount = int.Parse(Console.ReadLine());
        var exist = new bool[nodesCount];
        var nodes = new TreeNode<int>[nodesCount];

        for (int i = 0; i < nodesCount; i++)
        {
            nodes[i] = new TreeNode<int>(i);
        }

        for (int i = 0; i < nodesCount-1; i++)
        {
            var pair = Console.ReadLine().Split(' ');

            int parentId = int.Parse(pair[0]);
            int childId = int.Parse(pair[1]);

            nodes[parentId].AddChild(nodes[childId]);
        }

        //01.Find root node.
        TreeNode<int> root = FindRoot(nodes);
        Console.WriteLine("Root is: {0}", root.Value);

        //02.Find all leaf nodes.
        List<TreeNode<int>> leaves = FindLeafNodes(nodes);
        Console.Write("The leaf nodes are: ");
        for (int i = 0; i < leaves.Count; i++)
        {
            Console.Write(leaves[i].Value);
            if (i != (leaves.Count - 1))
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();

        //03.Find all middle nodes.
        List<TreeNode<int>> middleNodes = FindMiddleNodes(nodes);
        Console.Write("The leaf nodes are: ");
        for (int i = 0; i < middleNodes.Count; i++)
        {
            Console.Write(middleNodes[i].Value);
            if (i != (middleNodes.Count - 1))
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();

        //04.Find the longest path in the tree.
        int maxPath = FindLongestPath(root);
        Console.WriteLine("The longest path is: {0}", maxPath);

        //05.Find all paths in the tree with given sum S of their nodes. - not completed
        int S = 5;
        int sum = 0;
        bool[] visited = new bool[nodesCount];
        FindAllSPaths(root, sum,visited, S);

        //06. not solved
    }

    private static int FindAllSPaths(TreeNode<int> root, int sum, bool[] visited, int S)
    {
        sum += root.Value;
        path.Add(root);
        if (sum == 5)
        {
            allPaths.Add(path);
            path.Clear();
            sum = 0;
        }
        
        foreach (TreeNode<int> node in root.Children)
        {
            if (!visited[root.Value])
            {
                visited[root.Value] = true;
                FindAllSPaths(node, sum, visited, S);    
            }
            
        }

        return sum;
    }

    private static int FindLongestPath(TreeNode<int> root)
    {
        if (root.Children.Count == 0)
        {
            return 0;
        }

        int maxPath = 0;
        foreach (var item in root.Children)
        {
            maxPath = Math.Max(maxPath, FindLongestPath(item));
        }

        return maxPath + 1;
    }

    private static List<TreeNode<int>> FindMiddleNodes(TreeNode<int>[] nodes)
    {
        List<TreeNode<int>> middleNodes = new List<TreeNode<int>>();

        foreach (TreeNode<int> node in nodes)
        {
            if (node.Children.Count != 0 && node.hasParent)
            {
                middleNodes.Add(node);
            }
        }

        return middleNodes;
    }

    private static TreeNode<int> FindRoot(TreeNode<int>[] nodes)
    {
        TreeNode<int> root = new TreeNode<int>();
        foreach (TreeNode<int> node in nodes)
        {
            if (node == null)
            {
                continue;
            }

            if (node.hasParent == false)
            {
                root = node;
                break;
            }
        }

        return root;
    }

    private static List<TreeNode<int>> FindLeafNodes(TreeNode<int>[] nodes)
    {
        List<TreeNode<int>> leaves = new List<TreeNode<int>>();

        foreach (TreeNode<int> node in nodes)
        {
            if (node.Children.Count == 0)
            {
                leaves.Add(node);
            }
        }

        return leaves;
    }
}
