using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_node1
{
    class NaryNode<T>
    {
        public T Value { get; set; }
        public List<NaryNode<T>> Children { get; set; }
        public NaryNode(T _value)
        {
            Value = _value;
            Children = new List<NaryNode<T>>();
        }
        public void AddChild(NaryNode<T> _child)
        {
            Children.Add(_child);
        }
        public override string ToString()
        {
            string result = Value.ToString() + ":";
            
            for (int child = 0; child < Children.Count; child++)
            {
                result += " " + Children[child].Value.ToString();
            }
            
            return result;
        }
        public static void Output(NaryNode<T> _tree)
        {
            Console.WriteLine(_tree.ToString());
            for (int child = 0; child < _tree.Children.Count; child++)
            {
                Output(_tree.Children[child]);
            }
        }
    }
}


