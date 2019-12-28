using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    /// <summary>
    /// List of individuals
    /// </summary>
    /// <typeparam name="T">The type of the dna of the individuals in the population</typeparam>
    public class Population<T> : List<Individual<T>>
    {

        /// <summary>
        /// Get the best individual in the population
        /// </summary>
        /// <returns>The best individual</returns>
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

        /// <summary>
        /// Get the worst individual in the population
        /// </summary>
        /// <returns>The worst individual</returns>
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
