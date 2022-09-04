using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Ink;

namespace binary_node5
{
    internal class BinaryNode<T>
    {
        internal T Value { get; set; }
        internal BinaryNode<T> LeftChild, RightChild;

        // New constants and properties go here...
        public const double NODE_RADIUS = 30.0;
        public const double X_SPACING = 30.0;
        public const double Y_SPACING = 30.0;

        internal Point Center { get; set; }  
        internal Rect SubtreeBounds { get; set; }

        internal BinaryNode(T value)
        {
            Value = value;
            LeftChild = null;
            RightChild = null;
        }

        internal void AddLeft(BinaryNode<T> child)
        {
            LeftChild = child;
        }

        internal void AddRight(BinaryNode<T> child)
        {
            RightChild = child;
        }

        // Return an indented string representation of the node and its children.
        public override string ToString()
        {
            return ToString("");
        }

        // Recursively create a string representation of this node's subtree.
        // Display this value indented, followed by the left and right
        // values indented one more level.
        // End in a newline.
        public string ToString(string spaces)
        {
            // Create a string named result that initially holds the
            // current node's value followed by a new line.
            string result = string.Format("{0}{1}:\n", spaces, Value);

            // See if the node has any children.
            if ((LeftChild != null) || (RightChild != null))
            {
                // Add null or the child's value.
                if (LeftChild == null)
                    result += string.Format("{0}{1}null\n", spaces, "  ");
                else
                    result += LeftChild.ToString(spaces + "  ");

                // Add null or the child's value.
                if (RightChild == null)
                    result += string.Format("{0}{1}null\n", spaces, "  ");
                else
                    result += RightChild.ToString(spaces + "  ");
            }
            return result;
        }

        // Recursively search this node's subtree looking for the target value.
        // Return the node that contains the value or null.
        internal BinaryNode<T> FindNode(T target)
        {
            // See if this node contains the value.
            if (Value.Equals(target)) return this;

            // Search the left child subtree.
            BinaryNode<T> result = null;
            if (LeftChild != null)
                result = LeftChild.FindNode(target);
            if (result != null) return result;

            // Search the right child subtree.
            if (RightChild != null)
                result = RightChild.FindNode(target);
            if (result != null) return result;

            // We did not find the value. Return null.
            return null;
        }

        internal List<BinaryNode<T>> TraversePreorder()
        {
            List<BinaryNode<T>> result = new List<BinaryNode<T>>();

            // Add this node to the traversal.
            result.Add(this);

            // Add the child subtrees.
            if (LeftChild != null) result.AddRange(LeftChild.TraversePreorder());
            if (RightChild != null) result.AddRange(RightChild.TraversePreorder());
            return result;
        }

        internal List<BinaryNode<T>> TraverseInorder()
        {
            List<BinaryNode<T>> result = new List<BinaryNode<T>>();

            // Add the left subtree.
            if (LeftChild != null) result.AddRange(LeftChild.TraverseInorder());

            // Add this node.
            result.Add(this);

            // Add the right subtree.
            if (RightChild != null) result.AddRange(RightChild.TraverseInorder());
            return result;
        }

        internal List<BinaryNode<T>> TraversePostorder()
        {
            List<BinaryNode<T>> result = new List<BinaryNode<T>>();

            // Add the child subtrees.
            if (LeftChild != null) result.AddRange(LeftChild.TraversePostorder());
            if (RightChild != null) result.AddRange(RightChild.TraversePostorder());

            // Add this node.
            result.Add(this);
            return result;
        }

        internal List<BinaryNode<T>> TraverseBreadthFirst()
        {
            List<BinaryNode<T>> result = new List<BinaryNode<T>>();
            Queue<BinaryNode<T>> queue = new Queue<BinaryNode<T>>();

            // Start with the top node in the queue.
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                // Remove the top node from the queue and
                // add it to the result list.
                BinaryNode<T> node = queue.Dequeue();
                result.Add(node);

                // Add the node's children to the queue.
                if (node.LeftChild != null) queue.Enqueue(node.LeftChild);
                if (node.RightChild != null) queue.Enqueue(node.RightChild);
            }

            return result;
        }

        // New code goes here...
        private void ArrangeSubtree(double xmin, double ymin)
        {
            if (LeftChild == null && RightChild == null)
            {
                Center = new Point(xmin + NODE_RADIUS, ymin + NODE_RADIUS);
                SubtreeBounds = new Rect(xmin, ymin, 2 * NODE_RADIUS, 2 * NODE_RADIUS);
                return;
            }
            else if (LeftChild != null && RightChild != null)
            {
                LeftChild.ArrangeSubtree(xmin, ymin+2*NODE_RADIUS+Y_SPACING);
                RightChild.ArrangeSubtree(xmin+LeftChild.SubtreeBounds.Width+X_SPACING, ymin+2*NODE_RADIUS+Y_SPACING);
                Center = new Point(xmin + (LeftChild.SubtreeBounds.Width+X_SPACING+RightChild.SubtreeBounds.Width)/2.0, ymin + NODE_RADIUS);
                SubtreeBounds = new Rect(xmin,
                    ymin,
                    LeftChild.SubtreeBounds.Width + X_SPACING + RightChild.SubtreeBounds.Width,
                    2 * NODE_RADIUS + Y_SPACING + Math.Max(LeftChild.SubtreeBounds.Height, RightChild.SubtreeBounds.Height));
                return;
            }
            else
            {
                BinaryNode<T> Child = LeftChild != null ? LeftChild : RightChild;
                Child.ArrangeSubtree(xmin, ymin + 2 * NODE_RADIUS + Y_SPACING);
                Center = new Point(xmin + (Child.SubtreeBounds.Width) / 2.0, ymin + NODE_RADIUS);
                SubtreeBounds = new Rect(xmin,
                    ymin,
                    Child.SubtreeBounds.Width,
                    2 * NODE_RADIUS + Y_SPACING + Child.SubtreeBounds.Height);
                return;
            }
        }
        private void DrawSubtreeLinks(Canvas canvas)
        {
            if (LeftChild != null)
            {
                canvas.DrawLine(Center, LeftChild.Center, Brushes.Blue, 2.5);
                LeftChild.DrawSubtreeLinks(canvas);
            }
            if (RightChild != null)
            {
                canvas.DrawLine(Center, RightChild.Center, Brushes.Blue, 2.5);
                RightChild.DrawSubtreeLinks(canvas);
            }

        }
        private void DrawSubtreeNodes(Canvas canvas)
        {
            Rect rect = new Rect(Center.X-NODE_RADIUS,Center.Y-NODE_RADIUS,2*NODE_RADIUS,2*NODE_RADIUS);
            canvas.DrawEllipse(rect, Brushes.Yellow, Brushes.Blue, 2);
            canvas.DrawLabel(rect, Value, Brushes.Transparent, Brushes.Red, (HorizontalAlignment)1, (VerticalAlignment)1, NODE_RADIUS, 0);

            if (LeftChild != null)
            {
                LeftChild.DrawSubtreeNodes(canvas);
            }
            if (RightChild != null)
            {
                RightChild.DrawSubtreeNodes(canvas);
            }
        }
        internal void ArrangeAndDrawSubtree(Canvas canvas, double xmin, double ymin)
        {
            ArrangeSubtree(xmin, ymin);
            DrawSubtreeLinks(canvas);
            DrawSubtreeNodes(canvas);
        }
    }
}
