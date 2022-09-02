using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_node2
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
            return ToString("");
        }
        public string ToString(string spaces)
        {
            string result = spaces + Value.ToString() + ":\n" ;
            
            for (int child = 0; child < Children.Count; child++)
            {
                result += Children[child].ToString(spaces+"  ");
            }
            
            return result;
        }

        public NaryNode<T> FindNode(T _searchvalue)
        {
            if (Value.Equals(_searchvalue))
            {
                return this;
            }

            for (int child = 0; child < Children.Count; child++)
            {
                NaryNode<T> ChildFound = Children[child].FindNode(_searchvalue);
                if (ChildFound != null)
                {
                    return ChildFound;
                }
            }

            return null;
        }
    }
}


