namespace H01TreeNodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeNode<T>
    {
        private TreeNode<T> parent;
        private T value;

        private List<TreeNode<T>> childreanNodes;
 
        public TreeNode(T value, TreeNode<T> parent = null)
        {
            this.Parent = parent;
            this.Value = value;
            this.childreanNodes = new List<TreeNode<T>>();
        }

        public List<TreeNode<T>> ChildreanNodes
        {
            get
            {
                return this.childreanNodes;
            }

            set
            {
                this.childreanNodes = value;
            }
        }

        public TreeNode<T> Parent
        {
            get
            {
                return this.parent;
            }

            set
            {
                this.parent = value;
            }
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
