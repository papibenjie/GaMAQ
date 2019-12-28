using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    /// <summary>
    /// Class used to manipulate all population and making it interact with the selector and evaluator.
    /// </summary>
    /// <typeparam name="T">The type of the dna of the individuals</typeparam>
    class Environment<T>
    {
        private ISelector<T> selector;
        private IEvaluator<T> evaluator;
        public Population<T> Population { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="selector">Environement selector</param>
        /// <param name="evaluator">Environment evaluator</param>
        public Environment(ISelector<T> selector, IEvaluator<T> evaluator)
        {
            this.selector = selector;
            this.evaluator = evaluator;
            Population = new Population<T>();
        }

        /// <summary>
        /// Evaluate all individuals in the population
        /// </summary>
        public void EvaluateAll()
        {
            foreach (Individual<T> individual in Population)
            {
                individual.Fitness = evaluator.Evaluate(individual.Dna);
            }
        }

        /// <summary>
        /// Mutate all individuals in the population
        /// </summary>
        public void MutateAll()
        {
            foreach (Individual<T> individual in Population)
            {
                individual.Mutate();
            }
        }

        /// <summary>
        /// Select 'x' individuals in the population using the selector
        /// </summary>
        /// <param name="qty">The quantity of individuals to select</param>
        /// <returns>The selected individuals</returns>
        public List<Individual<T>> Select(int qty)
        {
            List<Individual<T>> selected = new List<Individual<T>>();
            for (int i = 0; i < qty; i++)
            {
                Individual<T> individual = selector.Select(Population);
                Population.Remove(individual);
                selected.Add(individual);
            }
            Population.AddRange(selected);
            return selected;
        }
    }
}
