using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace binary_node5
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Build a test tree.
            //         A
            //        / \
            //       /   \
            //      /     \
            //     B       C
            //    / \     / \
            //   D   E   F   G
            //      / \     /
            //     H   I   J
            //            / \
            //           K   L
            BinaryNode<string> node_a = new BinaryNode<string>("A");
            BinaryNode<string> node_b = new BinaryNode<string>("B");
            BinaryNode<string> node_c = new BinaryNode<string>("C");
            BinaryNode<string> node_d = new BinaryNode<string>("D");
            BinaryNode<string> node_e = new BinaryNode<string>("E");
            BinaryNode<string> node_f = new BinaryNode<string>("F");
            BinaryNode<string> node_g = new BinaryNode<string>("G");
            BinaryNode<string> node_h = new BinaryNode<string>("H");
            BinaryNode<string> node_i = new BinaryNode<string>("I");
            BinaryNode<string> node_j = new BinaryNode<string>("J");
            BinaryNode<string> node_k = new BinaryNode<string>("K");
            BinaryNode<string> node_l = new BinaryNode<string>("L");

            node_a.AddLeft(node_b);
            node_a.AddRight(node_c);
            node_b.AddLeft(node_d);
            node_b.AddRight(node_e);
            node_c.AddLeft(node_f);
            node_c.AddRight(node_g);
            node_e.AddLeft(node_h);
            node_e.AddRight(node_i);
            node_g.AddLeft(node_j);
            node_j.AddLeft(node_k);
            node_j.AddRight(node_l);

            // Arrange and draw the tree.
            node_a.ArrangeAndDrawSubtree(mainCanvas, 10, 10);
            double new_minx = 10 + node_a.SubtreeBounds.Width + BinaryNode<string>.X_SPACING;

            // Build a test tree.
            // A
            //         |
            //     +---+---+
            // B   C   D
            //     |       |
            //    +-+      +
            // E F      G
            //    |        |
            //    +      +-+-+
            // H      I J K
            NaryNode<string> node_aa = new NaryNode<string>("A");
            NaryNode<string> node_bb = new NaryNode<string>("B");
            NaryNode<string> node_cc = new NaryNode<string>("C");
            NaryNode<string> node_dd = new NaryNode<string>("D");
            NaryNode<string> node_ee = new NaryNode<string>("E");
            NaryNode<string> node_ff = new NaryNode<string>("F");
            NaryNode<string> node_gg = new NaryNode<string>("G");
            NaryNode<string> node_hh = new NaryNode<string>("H");
            NaryNode<string> node_ii = new NaryNode<string>("I");
            NaryNode<string> node_jj = new NaryNode<string>("J");
            NaryNode<string> node_kk = new NaryNode<string>("K");

            node_aa.AddChild(node_bb);
            node_aa.AddChild(node_cc);
            node_aa.AddChild(node_dd);
            node_bb.AddChild(node_ee);
            node_bb.AddChild(node_ff);
            node_dd.AddChild(node_gg);
            node_ee.AddChild(node_hh);
            node_gg.AddChild(node_ii);
            node_gg.AddChild(node_jj);
            node_gg.AddChild(node_kk);

            // Draw the tree.
            node_aa.ArrangeAndDrawSubtree(mainCanvas, new_minx, 10);
        }
    }
}
