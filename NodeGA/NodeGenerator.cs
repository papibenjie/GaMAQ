using GaMAQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGA
{
    class NodeGenerator : IGenerator<Tree>
    {
        public int MaxDepth { get; set; }
        public int MinDepth { get; set; }
        public List<int> PossibleConst { get; set; }

        private int currentDepth = 0;
        private Random rdm = new Random();

        public NodeGenerator(int minDepth, int maxDepth, List<int> possibleConst)
        {
            MaxDepth = maxDepth;
            MinDepth = minDepth;
            PossibleConst = possibleConst;
            currentDepth = 0;
        }

        public Tree Generate()
        {
            currentDepth = 0;
            return _generate();
        }

        private Tree _generate()
        {
            currentDepth++;
            Node node;
            if (currentDepth < MinDepth)
            {
                node = GenerateOperationNode();
            }
            else if (currentDepth > MaxDepth)
            {
                node = GenerateConstNode();
            }
            else
            {
                if (rdm.NextDouble() < 0.5)
                {
                    node = GenerateOperationNode();
                }
                else
                {
                    node = GenerateConstNode();
                }
            }
            return new Tree(node);
        }

        private Node GenerateConstNode()
        {
            return new ConstNode(PossibleConst[rdm.Next(PossibleConst.Count)]);
        }

        private Node GenerateOperationNode()
        {
            Node node = OperationEnum.GetAll().ToList()[rdm.Next(OperationEnum.GetAll().Count())].ToNode();
            node.Children.Add(_generate().Root);
            node.Children.Add(_generate().Root);
            return node;
        }
    }
}
