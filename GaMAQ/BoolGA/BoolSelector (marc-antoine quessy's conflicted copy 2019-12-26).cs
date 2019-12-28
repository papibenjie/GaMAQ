using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    class BoolSelector : ISelector<List<bool>>
    {
        Random rdm = new Random();

        public Individual<List<bool>> Select(Population<List<bool>> population)
        {
            double total = 0;
            foreach (Individual<List<bool>> individual in population)
            {
                total += individual.Fitness;
            }
            double choice = rdm.NextDouble() * total;
            double count = 0;
            foreach (Individual<List<bool>> individual in population)
            {
                count += individual.Fitness;
                if(count > choice)
                {
                    return individual;
                }
            }
            return population[0];
        }
    }
}
