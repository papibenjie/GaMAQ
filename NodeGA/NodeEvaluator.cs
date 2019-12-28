using GaMAQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGA
{
    class NodeEvaluator : IEvaluator<Tree>
    {
        public float Target;
        public int MaxNodes;

        public NodeEvaluator(float target, int maxNodes)
        {
            Target = target;
            MaxNodes = maxNodes;
        }

        public double Evaluate(Tree dna)
        {
            if(dna.GetNodes().Count > MaxNodes)
            {
                return 0;
            }
            return 1 / (Math.Abs(dna.Compute() - Target) + 1) * Math.Abs(MaxNodes - dna.GetNodes().Count) / 10;
        }
    }
}
