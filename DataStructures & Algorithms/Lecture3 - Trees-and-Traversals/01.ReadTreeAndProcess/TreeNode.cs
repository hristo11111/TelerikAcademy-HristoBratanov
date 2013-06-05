using System;
using System.Collections.Generic;
using System.Linq;

class TreeNode<T>
{
    public T Value { get; set; }
    public List<TreeNode<T>> Children { get; private set; }
    public bool hasParent { get; private set; }

    public TreeNode()
    {
        this.Children = new List<TreeNode<T>>();
    }

    public TreeNode(T value)
        : this()
    {
        this.Value = value;
    }

    public void AddChild(TreeNode<T> node)
    {
        if (node == null)
        {
            throw new ArgumentNullException("Null node cannot be added!");
        }

        node.hasParent = true;
        this.Children.Add(node);
    }
}
