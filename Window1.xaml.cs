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

using System.Diagnostics;

namespace sorted_binary_node1
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

        SortedBinaryNode<int> Root = null;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ValueTextBox.Focus();

            Root = new SortedBinaryNode<int>(-1);

            RunTests();

            DrawTree();
        }

        // Build a test tree.
        private void RunTests()
        {
            //60, 35, 76, 21, 42, 71, 89, 17, 24, 74, 11, 23, 72, 75
            int[] testNodes = { 60, 35, 76, 21, 42, 71, 89, 17, 24, 74, 11, 23, 72, 75 };
            foreach(int value in testNodes)
            {
                Root.AddNode(value);
            }
            
            bool bFoundAll = true;
            SortedBinaryNode<int> node = null;

            foreach (int value in testNodes)
            {
                node = Root.FindNode(value);
                bFoundAll = (node != null) && bFoundAll;
                if (node != null)
                {
                    Debug.Assert(node.Value == value);
                }
            }

            if (bFoundAll)
            {
                //MessageBox.Show("Found all nodes");
            }
            else
            {
                MessageBox.Show("Found not all nodes");
            }
        }

        // Draw the tree.
        private void DrawTree()
        {
            mainCanvas.Children.Clear();

            Root.ArrangeAndDrawSubtree(mainCanvas, 5, 5);
        }


        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            int value;
            if (!int.TryParse(ValueTextBox.Text, out value) || (value < 0))
            {
                MessageBox.Show("The value must be a non-negative integer.");
            }
            else
            {
                try
                {
                    Root.AddNode(value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            DrawTree();

            ValueTextBox.Focus();
            ValueTextBox.Clear();


        }

        private void findButton_Click(object sender, RoutedEventArgs e)
        {
            int value;
            if (!int.TryParse(ValueTextBox.Text, out value))
            {
                MessageBox.Show("The value must be an integer.");
            }
            else
            {
                SortedBinaryNode<int> node = null;
                try
                {
                    node = Root.FindNode(value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                if (node == null)
                {
                    MessageBox.Show(string.Format("The value {0} is not in the tree.", value));
                }
                else
                {
                    MessageBox.Show(string.Format("Found value {0}.", node.Value));
                }
            }

            DrawTree();

            ValueTextBox.Focus();
            ValueTextBox.Clear();
        }

        private void removeButton_Click(object sender, RoutedEventArgs e)
        {
            int value;
            if (!int.TryParse(ValueTextBox.Text, out value))
            {
                MessageBox.Show("The value must be an integer.");
            }
            else
            {
                try
                {
                    Root.RemoveNode(value);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            DrawTree();

            ValueTextBox.Focus();
            ValueTextBox.Clear();
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            Root = new SortedBinaryNode<int>(-1);
            
            DrawTree();

            ValueTextBox.Focus();
            ValueTextBox.Clear();
        }
    }
}
