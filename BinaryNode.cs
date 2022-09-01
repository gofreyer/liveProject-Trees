using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_node1
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
            return Value.ToString() + ": " + (LeftChild == null ? "null" : LeftChild.Value.ToString()) + " " + (RightChild == null ? "null" : RightChild.Value.ToString());
        }
        public static void Output(BinaryNode<T> _tree)
        {
            if (_tree != null)
            {
                Console.WriteLine(_tree.ToString());
                Output(_tree.LeftChild);
                Output(_tree.RightChild);
            }
        }
    }
}
