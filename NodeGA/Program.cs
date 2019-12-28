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
            List<float> possibleConst = new List<float> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            NodeEvaluator evaluator = new NodeEvaluator(57, 25);
            NodeGenerator generator = new NodeGenerator(3, 5, possibleConst);
            NodeMutator mutator = new NodeMutator(possibleConst, OperationEnum.GetAll(), new NodeGenerator(1, 3, possibleConst), 0.05f, 0.005f); ;
            NodeReproductor reproductor = new NodeReproductor();
            NodeSelector selector = new NodeSelector();

            GeneticAlgorithm<Tree> GA = new GeneticAlgorithm<Tree>(evaluator, generator, selector);

            GA.Initialize(100, mutator, reproductor);

            Tree tree1 = generator.Generate();
            Tree tree2 = generator.Generate();

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
