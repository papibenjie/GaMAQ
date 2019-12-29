using GaMAQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGA
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> possibleConst = new List<int> { 1,5,10, 50};

            NodeEvaluator evaluator = new NodeEvaluator(124, 50);

            NodeGenerator generator = new NodeGenerator(3, 6, possibleConst);
            NodeMutator mutator = new NodeMutator(possibleConst, OperationEnum.GetAll(), new NodeGenerator(1, 5, possibleConst), 0.02f, 0.003f); ;
            NodeReproductor reproductor = new NodeReproductor();
            NodeSelector selector = new NodeSelector();

            GeneticAlgorithm<Tree> GA = new GeneticAlgorithm<Tree>(evaluator, generator, selector);

            GA.Initialize(150, mutator, reproductor);

            for (int i = 0; i < 100000; i++)
            {
                
                GA.NextStep();
              

                if (i % 250 == 0)
                {
                    Individual<Tree> best = GA.GetBest();
                    Console.WriteLine("FIT: {0}", best.Fitness);
                    best.Dna.PrintTree();
                    Console.WriteLine(best.Dna.Root.ToExpr());
                    Console.WriteLine("--------------------------------------");
                }
            }


            Console.ReadLine();
        }
    }
}
