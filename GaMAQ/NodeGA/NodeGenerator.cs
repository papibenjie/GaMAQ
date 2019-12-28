using GaMAQ.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ.NodeGA
{
    class NodeGenerator : IGenerator<Tree>
    {
        private double constNodeRate = 0;
       
        private List<double> possibleConst = new List<double>();
        private List<Node> possibleOp = new List<Node>();

        private int maxDepth = 0;
        private int minDepth = 0;
        private int depthIdx = 1;

        private Random rdm = new Random();

        

        public NodeGenerator(double constNodeRate, List<double> possibleConst, int minDepth, int maxDepth)
        {
            this.constNodeRate = constNodeRate;
            this.possibleConst = possibleConst;
            this.maxDepth = maxDepth;
            this.minDepth = minDepth;

            possibleOp.Add(new AddNode());
            possibleOp.Add(new SubNode());
            possibleOp.Add(new MulNode());
            possibleOp.Add(new DivNode());

        }

        public Tree generate()
        {
            Node node = null;  
            if ((rdm.NextDouble() < constNodeRate && depthIdx >= minDepth) || depthIdx >= maxDepth)
            {
                node = new ConstNode(possibleConst[rdm.Next(possibleConst.Count)]);
            }
            else
            {
                depthIdx++;
                node = (Node)possibleOp[rdm.Next(possibleOp.Count)].Clone();
                node.Children.Add(generate().Root);
                node.Children.Add(generate().Root);
                foreach (Node child in node.Children)
                {
                    child.Parent = node;
                }
                depthIdx--;
            }
        
            return new Tree(node);
        }
    }
}
