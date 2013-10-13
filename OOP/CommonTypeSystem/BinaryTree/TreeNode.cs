using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class TreeNode<BinarySearchTree> : IEnumerable<BinarySearchTree>, ICloneable
       
    {
        private List<BinarySearchTree> binTreeArray;


        public TreeNode(List<BinarySearchTree> binTreeArray)
        {
            this.BinTreeArray = binTreeArray;
        }

        public List<BinarySearchTree> BinTreeArray
        {
            get
            {
                return this.binTreeArray;
            }
            set
            {
                this.binTreeArray = value;
            }
        }

        public IEnumerator<BinarySearchTree> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
