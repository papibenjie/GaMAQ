using GaMAQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGA
{
    class NodeMutator : IMutator<Tree>
    {
        public List<int> PossibleConst { get; set; } = new List<int>();
        public List<OperationEnum> PossibleOperation { get; set; } = new List<OperationEnum>();
        public IGenerator<Tree> Generator { get; set; }

        public float Rate { get; set; } = 0.01f;
        public float HardRate { get; set; } = 0.01f;

        private Random rdm = new Random();

        public NodeMutator(List<int> possibleConst, List<OperationEnum> possibleOperation, IGenerator<Tree> generator, float rate, float hardRate)
        {
            PossibleConst = possibleConst;
            PossibleOperation = possibleOperation;
            Generator = generator;
            Rate = rate;
        }

        public void Mutate(ref Tree dna)
        {
            if(rdm.NextDouble() < Rate)
            {
                List<Node> nodes = dna.GetNodes();
                Node node = nodes[rdm.Next(nodes.Count)];
                if(node.Children.Count == 0)
                {
                    dna.ReplaceNodes(node, new ConstNode(PossibleConst[rdm.Next(PossibleConst.Count)]));
                }
                else
                {
                    dna.ReplaceNodes(node, PossibleOperation[rdm.Next(PossibleOperation.Count)].ToNode());
                }
            }
            if (rdm.NextDouble() < HardRate)
            {
                List<Node> nodes = dna.GetNodes();
                Node node = nodes[rdm.Next(nodes.Count)];
                dna.ReplaceNodes(node, Generator.Generate().Root, true);
            }
        }
    }
}
