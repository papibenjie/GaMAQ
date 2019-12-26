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
    }
}
