
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaMAQ
{
    class Program
    {
        static void Main(string[] args)
        {
            BoolEvaluator evaluator = new BoolEvaluator(Enumerable.Repeat(true, 100).ToList());
            BoolGenerator generator = new BoolGenerator(100);
            BoolMutator mutator = new BoolMutator(0.01, 0);
            BoolReproductor reproductor = new BoolReproductor();
            BoolSelector selector = new BoolSelector();

            GeneticAlgorithm<List<bool>> GA = new GeneticAlgorithm<List<bool>>(evaluator, generator, selector);

            GA.Initialize(100, mutator, reproductor);

            for (int i = 0; i < 1000; i++)
            {
                GA.NextStep();
                Individual<List<bool>> best = GA.GetBest();
                foreach (var val in best.Dna)
                {
                    Console.Write(val ? "1" : "0");
                }
                Console.WriteLine("  -----  {0}", best.Fitness);
            }

            Console.Read();
        }
    }
}



