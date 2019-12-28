using GaMAQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGA
{
    class NodeSelector : ISelector<Tree>
    {
        private Random rdm = new Random();
        public Individual<Tree> Select(Population<Tree> population)
        {
            double total = 0;
            foreach (Individual<Tree> individual in population)
            {
                total += individual.Fitness;
            }
            double choice = rdm.NextDouble() * total;
            double count = 0;
            foreach (Individual<Tree> individual in population)
            {
                count += individual.Fitness;
                if (count > choice)
                {
                    return individual;
                }
            }
            return population[0];
        }
    }
}
