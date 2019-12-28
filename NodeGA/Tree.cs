using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGA
{
    class Tree
    {
        public Node Root { get; set; }

        public Tree(Node root)
        {
            Root = root;
        }

        public void PrintTree()
        {
            Root.PrintTree(0);
        }

        public float Compute()
        {
            return Root.Compute();
        }

        public List<Node> GetNodes()
        {
            return Root.GetNodes(new List<Node>());
        }

        public void ReplaceNodes(Node target, Node goal, bool keepChild = false)
        {
            if(target.Equals(Root) && !keepChild)
            {
                goal.Children.Clear();
                goal.Children.AddRange(Root.Children);
                Root = goal;

            }
            else
            {
                Root.ReplaceNodes(target, goal, keepChild);
            }    
        }

        public int GetDepth()
        {
            return Root.GetRemainingDepth(0);
        }

        public Tree Clone()
        {
            return new Tree(Root.Clone());
        }
    }
}
