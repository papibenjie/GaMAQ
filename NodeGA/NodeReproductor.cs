using GaMAQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGA
{
    class NodeReproductor : IReproductor<Tree>
    {
        private Random rdm = new Random();

        public Tree Reproduce(Tree dna1, Tree dna2)
        {
            Tree offspring = dna1.Clone();

            List<Node> nodes1 = dna1.GetNodes();
            List<Node> nodes2 = dna2.GetNodes();

            Node target = nodes1[rdm.Next(nodes1.Count)];
            Node goal = nodes2[rdm.Next(nodes2.Count)];

            offspring.ReplaceNodes(target, goal, true);

            return offspring;
        }
    }
}
