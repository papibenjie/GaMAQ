using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ.NodeGA
{
    class NodeSelector : ISelector<Node>
    {

        private Random rdm = new Random();

        public Individual<Node> Select(Population<Node> population)
        {
            // Invert data
            double highest = population.GetBest().Fitness;
            foreach (Individual<Node> individual in population)
            {
                individual.Fitness = highest - individual.Fitness + 1;
            }

            // weighted choice
            double total = 0;
            foreach (Individual<Node> individual in population)
            {
                total += individual.Fitness;
            }
            double choice = rdm.NextDouble() * total;
            double count = 0;
            foreach (Individual<Node> individual in population)
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
