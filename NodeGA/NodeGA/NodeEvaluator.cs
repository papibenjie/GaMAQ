using GaMAQ.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ.NodeGA
{
    class NodeEvaluator : IEvaluator<Tree>
    {
        private double answer = 0;

        public NodeEvaluator(double answer)
        {
            this.answer = answer;
        }

        public double Evaluate(Tree dna)
        {
            return Math.Pow(Math.Abs(answer - dna.Root.compute()), 2);
        }
    }
}
