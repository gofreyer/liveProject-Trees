using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_node2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Binary Nodes

            BinaryNode<string> Root_1 = new BinaryNode<string>("Root");
            BinaryNode<string> A_1 = new BinaryNode<string>("A");
            BinaryNode<string> B_1 = new BinaryNode<string>("B");
            BinaryNode<string> C_1 = new BinaryNode<string>("C");
            BinaryNode<string> D_1 = new BinaryNode<string>("D");
            BinaryNode<string> E_1 = new BinaryNode<string>("E");
            BinaryNode<string> F_1 = new BinaryNode<string>("F");

            Root_1.AddLeft(A_1);
            Root_1.AddRight(B_1);
            A_1.AddLeft(C_1);
            A_1.AddRight(D_1);
            B_1.AddRight(E_1);
            E_1.AddLeft(F_1);
            
            Console.WriteLine("\nBinaryNodes Output:\n");
            Console.WriteLine(Root_1);
            Console.WriteLine(A_1);

            // Nary Nodes

            NaryNode<string> Root_2 = new NaryNode<string>("Root");
            NaryNode<string> A_2 = new NaryNode<string>("A");
            NaryNode<string> B_2 = new NaryNode<string>("B");
            NaryNode<string> C_2 = new NaryNode<string>("C");
            NaryNode<string> D_2 = new NaryNode<string>("D");
            NaryNode<string> E_2 = new NaryNode<string>("E");
            NaryNode<string> F_2 = new NaryNode<string>("F");
            NaryNode<string> G_2 = new NaryNode<string>("G");
            NaryNode<string> H_2 = new NaryNode<string>("H");
            NaryNode<string> I_2 = new NaryNode<string>("I");

            Root_2.AddChild(A_2);
            Root_2.AddChild(B_2);
            Root_2.AddChild(C_2);
            A_2.AddChild(D_2);
            A_2.AddChild(E_2);
            C_2.AddChild(F_2);
            D_2.AddChild(G_2);
            F_2.AddChild(H_2);
            F_2.AddChild(I_2);

            Console.WriteLine("\nNaryNodes Output:\n");
            Console.WriteLine(Root_2);
            Console.WriteLine(A_2);
            
            Console.ReadLine();
        }
    }
}
