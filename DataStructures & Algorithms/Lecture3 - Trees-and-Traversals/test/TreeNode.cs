using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class TreeNode<T>
    {
        private bool hasParent;
        private List<TreeNode<T>> children;
        private T value;

        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            this.value = value;
            this.children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException();
            }

            if (child.hasParent)
            {
                throw new ArgumentException();
            }

            child.hasParent = true;
            this.children.Add(child);
        }

        public int ChildrenCount
        {
            get { return this.children.Count; }
        }

        public TreeNode<T> GetChild(int index)
        {
            if (index < 0 || index >= this.children.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return this.children[index];
        }
    }
}
