using GaMAQ.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ.NodeGA
{
    class NodeReproductor : IReproductor<Tree>
    {

        Random rdm = new Random();

        public Tree reproduce(Tree adn1, Tree adn2)
        {
            Tree tree1 = adn1.Clone();
            Tree tree2 = adn2.Clone();
            List<Node> nodes1 = tree1.getNodeList();
            List<Node> nodes2 = tree2.getNodeList();
            Node selected1 = nodes1[rdm.Next(nodes1.Count)];
            Node selected2 = nodes2[rdm.Next(nodes2.Count)];
            while (selected1.Children.Count != selected2.Children.Count)
            {
                selected2 = nodes2[rdm.Next(nodes2.Count)];
            }
            
            Node newRoot = tree2.Root.replaceNode(selected1, selected2);
         
            return new Tree(newRoot);
        }
    }
}
