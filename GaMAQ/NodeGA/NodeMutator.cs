using GaMAQ.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ.NodeGA
{
    class NodeMutator : IMutator<Node>
    {

        private double mutateRate = 0;

        private NodeGenerator generator;

        private Random rdm = new Random();

        public NodeMutator(double mutateRate, NodeGenerator generator)
        {
            this.mutateRate = mutateRate;
            this.generator = generator;
        }

        public void mutate(ref Node dna)
        {
            if(rdm.NextDouble() < mutateRate)
            {
                dna = generator.generate().Root;
            }
            else
            {
                for (int i = 0; i < dna.Children.Count; i++)
                {
                    Node child = dna.Children[i];
                    mutate(ref child);
                    dna.Children[i] = child;
                }
            }
        }
    }
}
