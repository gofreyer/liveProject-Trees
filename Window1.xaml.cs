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

namespace nary_node6
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

        private void Window_Loaded(object sender, RoutedEventArgs rea)
        {
            NaryNode<string> a = new NaryNode<string>("GeneriGloop");
            NaryNode<string> b = new NaryNode<string>("R & D");
            NaryNode<string> c = new NaryNode<string>("Sales");
            NaryNode<string> d = new NaryNode<string>("Professional\nServices");
            NaryNode<string> e = new NaryNode<string>("HR");
            NaryNode<string> f = new NaryNode<string>("Accounting");
            NaryNode<string> g = new NaryNode<string>("Legal");

            NaryNode<string> b1 = new NaryNode<string>("Applied");
            NaryNode<string> b2 = new NaryNode<string>("Basic");
            NaryNode<string> b3 = new NaryNode<string>("Advanced");
            NaryNode<string> b4 = new NaryNode<string>("Sci Fi");

            NaryNode<string> c1 = new NaryNode<string>("Inside\nSales");
            NaryNode<string> c2 = new NaryNode<string>("Outside\nSales");
            NaryNode<string> c3 = new NaryNode<string>("B2B");
            NaryNode<string> c4 = new NaryNode<string>("Consumer");
            NaryNode<string> c5 = new NaryNode<string>("Account\nManagement");

            NaryNode<string> e1 = new NaryNode<string>("Training");
            NaryNode<string> e2 = new NaryNode<string>("Hiring");
            NaryNode<string> e3 = new NaryNode<string>("Equity");
            NaryNode<string> e4 = new NaryNode<string>("Discipline");

            NaryNode<string> f1 = new NaryNode<string>("Payroll");
            NaryNode<string> f2 = new NaryNode<string>("Billing");
            NaryNode<string> f3 = new NaryNode<string>("Reporting");
            NaryNode<string> f4 = new NaryNode<string>("Opacity");

            NaryNode<string> g1 = new NaryNode<string>("Compliance");
            NaryNode<string> g2 = new NaryNode<string>("Progress\nPrevention");
            NaryNode<string> g3 = new NaryNode<string>("Bail\nServices");
        
            a.AddChild(b);
            a.AddChild(c);
            a.AddChild(d);
            
            b.AddChild(b1);
            b.AddChild(b2);
            b.AddChild(b3);
            b.AddChild(b4);

            c.AddChild(c1);
            c.AddChild(c2);
            c.AddChild(c3);
            c.AddChild(c4);
            c.AddChild(c5);

            d.AddChild(e);
            d.AddChild(f);
            d.AddChild(g);

            e.AddChild(e1);
            e.AddChild(e2);
            e.AddChild(e3);
            e.AddChild(e4);

            f.AddChild(f1);
            f.AddChild(f2);
            f.AddChild(f3);
            f.AddChild(f4);

            g.AddChild(g1);
            g.AddChild(g2);
            g.AddChild(g3);

            // Draw the tree.
            a.ArrangeAndDrawSubtree(mainCanvas, 10, 10);

        }
    }
}
