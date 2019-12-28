using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ.Nodes
{
    class Tree
    {
        public Node Root { get; set; }

        public Tree(Node root)
        {
            Root = root;
        }

        public List<Node> getNodeList()
        {
            return Root.getNodesList();
        }

        public void printTree()
        {
            Root.printTree(0);
        }

        public Tree Clone()
        {
            Node root = (Node)Root.Clone();
            return new Tree(root);
        }
    }
}
