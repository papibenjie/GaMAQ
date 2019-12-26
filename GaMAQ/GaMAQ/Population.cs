using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    public class Population<T> : List<Individual<T>>
    {
        public Individual<T> GetBest()
        {
            Individual<T> best = this[0];
            foreach(Individual<T> individual in this)
            {
                if(individual.Fitness > best.Fitness)
                {
                    best = individual;
                }
            }
            return best;
        }

        public Individual<T> GetWorst()
        {
            Individual<T> best = this[0];
            foreach (Individual<T> individual in this)
            {
                if (individual.Fitness < best.Fitness)
                {
                    best = individual;
                }
            }
            return best;
        }
    }
}
