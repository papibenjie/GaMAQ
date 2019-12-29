using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGA
{
    public class Node
    {
        public Func<int[], int> Func { get; set; }
        public string Name { get; set; } = "NONAME";
        public int ID = 0;

        private static int lastID = 0;

        public List<Node> Children { get; set; } = new List<Node>();

        public Node(string name, Func<int[], int> func)
        {
            Func = func;
            Name = name;
            ID = lastID + 1;
            lastID++;
        }

        public int Compute()
        {
            int[] vals = Children.Select(n => n.Compute()).ToArray();
            return Func(vals);
        }

        public void PrintTree(int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                Console.Write("----");
            }
            Console.WriteLine(ToString());

            Children.ForEach(child => child.PrintTree(depth + 1));
        }

        public List<Node> GetNodes(List<Node> initial)
        {
            initial.Add(this);
            foreach (var child in Children)
            {
                child.GetNodes(initial);
            }
            return initial;
        }

        /// <summary>
        /// Replace a node in the descendants, not the current node
        /// </summary>
        /// <param name="target"></param>
        /// <param name="goal"></param>
        public void ReplaceNodes(Node target, Node node, bool keepChild=false)
        {
            foreach (var child in Children)
            {
                if(child.Equals(target))
                {
                    if(!keepChild)
                    {
                        node.Children.Clear();
                        node.Children.AddRange(child.Children);
                    }
                    Children.Remove(child);
                    Children.Add(node);
                    return;
                }
                child.ReplaceNodes(target, node, keepChild);
            }
        }

        public string ToExpr(string initial="")
        {
            if(Children.Count == 2)
            {
                initial = "(" + Children[0].ToExpr(initial) + " " + Name + " " + Children[1].ToExpr(initial) + ")";
            }
            else
            {
                return initial + Name;
            }
            return initial;
        }

        public int GetRemainingDepth(int currentDepth)
        {
            if(Children.Count > 0)
            {
                return Children.Select(c => c.GetRemainingDepth(currentDepth + 1)).Max();
            }
            return currentDepth + 1;
            
        }

        public Node Clone()
        {
            Node node = new Node(Name, Func);
            foreach (var child in Children)
            {
                node.Children.Add(child.Clone());
            }
            return node;
        }

        public bool Equals(Node node)
        {
            return ID.Equals(node.ID);
        }

        public override string ToString()
        {
            return String.Format("{0}({1})", Name, Compute());
        }
    }
}
