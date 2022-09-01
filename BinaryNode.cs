using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_node2
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
        public void AddLeft(BinaryNode<T>? _left)
        {
            LeftChild = _left;
        }
        public void AddRight(BinaryNode<T>? _right)
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
    }
}
