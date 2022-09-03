using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_node4
{
    class BinaryNode<T>
    {
        public T Value { get; set; }
        public BinaryNode<T> LeftChild { get; set; }
        public BinaryNode<T> RightChild { get; set; }
        public BinaryNode(T _value)
        {
            Value = _value;
            LeftChild = null;
            RightChild = null;
        }
        public void AddLeft(BinaryNode<T> _left)
        {
            LeftChild = _left;
        }
        public void AddRight(BinaryNode<T> _right)
        {
            RightChild = _right;
        }
        public override string ToString()
        {
            return ToString("");
        }
        public string ToString(string spaces)
        {
            string result = spaces + Value.ToString() + ":\n";
            if (LeftChild != null && RightChild != null)
            {
                string resultLeft = LeftChild.ToString(spaces + "  ");
                string resultRight = RightChild.ToString(spaces + "  ");

                result += resultLeft+resultRight;
            }
            else if(LeftChild == null && RightChild != null)
            {
                string resultLeft = spaces + "  " + "None\n";
                string resultRight = RightChild.ToString(spaces + "  ");

                result += resultLeft + resultRight;
            }
            else if (LeftChild != null && RightChild == null)
            {
                string resultRight = spaces + "  " + "None\n";
                string resultLeft = LeftChild.ToString(spaces + "  ");

                result += resultLeft + resultRight;
            }
            else if (LeftChild == null && RightChild == null)
            {
               
            }

            return result;
        }

        public BinaryNode<T> FindNode(T _searchvalue)
        {
            if (Value.Equals(_searchvalue))
            {
                return this;
            }
            if (LeftChild != null)
            {
                BinaryNode<T> LeftFound = LeftChild.FindNode(_searchvalue);
                if (LeftFound != null)
                {
                    return LeftFound;
                }
            }
            if (RightChild != null)
            {
                BinaryNode<T> RightFound = RightChild.FindNode(_searchvalue);
                if (RightFound != null)
                {
                    return RightFound;
                }
            }

            return null;
        }

        public List<BinaryNode<T>> TraversePreorder()
        {
            List<BinaryNode<T>> result = new List<BinaryNode<T>>();
            result.Add(this); 
            if (LeftChild != null)
            {
                result.AddRange(LeftChild.TraversePreorder());
            }
            if (RightChild != null)
            {
                result.AddRange(RightChild.TraversePreorder());
            }
            return result;
        }
        public List<BinaryNode<T>> TraverseInorder()
        {
            List<BinaryNode<T>> result = new List<BinaryNode<T>>();
            if (LeftChild != null)
            {
                result.AddRange(LeftChild.TraverseInorder());
            }
            result.Add(this);
            if (RightChild != null)
            {
                result.AddRange(RightChild.TraverseInorder());
            }
            return result;
        }
        public List<BinaryNode<T>> TraversePostorder()
        {
            List<BinaryNode<T>> result = new List<BinaryNode<T>>();
            if (LeftChild != null)
            {
                result.AddRange(LeftChild.TraversePostorder());
            }
            if (RightChild != null)
            {
                result.AddRange(RightChild.TraversePostorder());
            }
            result.Add(this);
            return result;
        }
        public List<BinaryNode<T>> TraverseBreadthFirst()
        {
            List<BinaryNode<T>> result = new List<BinaryNode<T>>();
            Queue<BinaryNode<T>> queue = new Queue<BinaryNode<T>>();
            BinaryNode<T> item = null;
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                result.Add(item);
                if (item.LeftChild != null)
                {
                    queue.Enqueue(item.LeftChild);
                }
                if (item.RightChild != null)
                {
                    queue.Enqueue(item.RightChild);
                }
            }

            return result;
        }

    }
}
