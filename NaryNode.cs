using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;

namespace binary_node5
{
    internal class NaryNode<T>
    {
        internal T Value { get; set; }
        internal List<NaryNode<T>> Children;

        // New constants and properties go here...
        public const double NODE_RADIUS = 30.0;
        public const double X_SPACING = 30.0;
        public const double Y_SPACING = 30.0;

        internal Point Center { get; set; }
        internal Rect SubtreeBounds { get; set; }

        internal NaryNode(T value)
        {
            Value = value;
            Children = new List<NaryNode<T>>();
        }

        internal void AddChild(NaryNode<T> child)
        {
            Children.Add(child);
        }

        // Return an indented string representation of the node and its children.
        public override string ToString()
        {
            return ToString("");
        }

        // Recursively create a string representation of this node's subtree.
        // Display this value indented, followed its children indented one more level.
        // End in a newline.
        public string ToString(string spaces)
        {
            // Create a string named result that initially holds the
            // current node's value followed by a new line.
            string result = string.Format("{0}{1}:\n", spaces, Value);

            // Add the children representations
            // indented by one more level.
            foreach (NaryNode<T> child in Children)
                result += child.ToString(spaces + "  ");
            return result;
        }

        // Recursively search this node's subtree looking for the target value.
        // Return the node that contains the value or null.
        internal NaryNode<T> FindNode(T target)
        {
            // See if this node contains the value.
            if (Value.Equals(target)) return this;

            // Search the child subtrees.
            foreach (NaryNode<T> child in Children)
            {
                NaryNode<T> result = child.FindNode(target);
                if (result != null) return result;
            }

            // We did not find the value. Return null.
            return null;
        }

        internal List<NaryNode<T>> TraversePreorder()
        {
            List<NaryNode<T>> result = new List<NaryNode<T>>();

            // Add this node to the traversal.
            result.Add(this);

            // Add the children.
            foreach (NaryNode<T> child in Children)
            {
                result.AddRange(child.TraversePreorder());
            }

            return result;
        }

        internal List<NaryNode<T>> TraversePostorder()
        {
            List<NaryNode<T>> result = new List<NaryNode<T>>();

            // Add the children.
            foreach (NaryNode<T> child in Children)
            {
                result.AddRange(child.TraversePreorder());
            }

            // Add this node to the traversal.
            result.Add(this);
            return result;
        }

        internal List<NaryNode<T>> TraverseBreadthFirst()
        {
            List<NaryNode<T>> result = new List<NaryNode<T>>();
            Queue<NaryNode<T>> queue = new Queue<NaryNode<T>>();

            // Start with the top node in the queue.
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                // Remove the top node from the queue and
                // add it to the result list.
                NaryNode<T> node = queue.Dequeue();
                result.Add(node);

                // Add the node's children to the queue.
                foreach (NaryNode<T> child in node.Children)
                    queue.Enqueue(child);
            }

            return result;
        }

        // New code goes here...
        private void ArrangeSubtree(double xmin, double ymin)
        {
            if (Children.Count == 0)
            {
                Center = new Point(xmin + NODE_RADIUS, ymin + NODE_RADIUS);
                SubtreeBounds = new Rect(xmin, ymin, 2 * NODE_RADIUS, 2 * NODE_RADIUS);
                return;
            }
            double last_x = 0;
            double new_x = xmin;
            double max_height = 0;

            foreach (NaryNode<T> child in Children)
            {
                if (last_x > 0)
                {
                    new_x = last_x + X_SPACING;
                }
                child.ArrangeSubtree(new_x, ymin + 2 * NODE_RADIUS + Y_SPACING);
                last_x = new_x + child.SubtreeBounds.Width;
                if (child.SubtreeBounds.Height > max_height)
                {
                    max_height = child.SubtreeBounds.Height;
                }
            }

            Center = new Point(xmin + (last_x-xmin)/2.0, ymin + NODE_RADIUS);
            SubtreeBounds = new Rect(xmin,
                    ymin,
                    last_x - xmin,
                    2 * NODE_RADIUS + Y_SPACING + max_height);
        }
        private void DrawSubtreeLinks(Canvas canvas)
        {
            // first only direct links
            foreach (NaryNode<T> child in Children)
            {
                //canvas.DrawLine(Center, child.Center, Brushes.Blue, 2.5);
                Point via1 = new Point(Center.X, Center.Y+(child.Center.Y-Center.Y)/2.0);
                Point via2 = new Point(child.Center.X, Center.Y + (child.Center.Y - Center.Y) / 2.0);
                canvas.DrawLine(Center, via1, Brushes.Blue, 2.5);
                canvas.DrawLine(via2, via1, Brushes.Blue, 2.5);
                canvas.DrawLine(child.Center, via2, Brushes.Blue, 2.5);

                child.DrawSubtreeLinks(canvas);
            }
        }
        private void DrawSubtreeNodes(Canvas canvas)
        {
            Rect rect = new Rect(Center.X - NODE_RADIUS, Center.Y - NODE_RADIUS, 2 * NODE_RADIUS, 2 * NODE_RADIUS);
            canvas.DrawEllipse(rect, Brushes.Green, Brushes.Blue, 2);
            canvas.DrawLabel(rect, Value, Brushes.Transparent, Brushes.Red, (HorizontalAlignment)1, (VerticalAlignment)1, NODE_RADIUS, 0);

            foreach (NaryNode<T> child in Children)
            {
                child.DrawSubtreeNodes(canvas);
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
