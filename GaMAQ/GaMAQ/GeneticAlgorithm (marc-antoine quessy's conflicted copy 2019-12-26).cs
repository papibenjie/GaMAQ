using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    /// <summary>
    /// Main class of GA
    /// </summary>
    /// <typeparam name="T">The type of the dna to evolve</typeparam>
    class GeneticAlgorithm<T>
    {
        private IEvaluator<T> evaluator;
        private IGenerator<T> generator;
        private ISelector<T> selector;

        private Environment<T> environment;

        /// <summary>
        /// GA constructor
        /// </summary>
        /// <param name="evaluator">GA evaluator</param>
        /// <param name="generator">GA generator</param>
        /// <param name="selector">GA selector</param>
        public GeneticAlgorithm(IEvaluator<T> evaluator, IGenerator<T> generator, ISelector<T> selector)
        {
            this.generator = generator;
            environment = new Environment<T>(selector, evaluator);
        }

        /// <summary>
        /// Get the best individual in the population (highest fitness) 
        /// </summary>
        /// <returns>The best individual</returns>
        public Individual<T> GetBest()
        {
            return environment.Population.GetBest();
        }

        /// <summary>
        /// Generate the initial population
        /// </summary>
        /// <param name="popSize">The size of the population</param>
        /// <param name="mutator">The base mutator</param>
        /// <param name="reproductor">The base reproductor</param>
        public void Initialize(int popSize, IMutator<T> mutator, IReproductor<T> reproductor)
        {
            for (int i = 0; i < popSize; i++)
            {
                T adn = generator.Generate();
                Individual<T> individual = new Individual<T>(mutator, reproductor, adn);
                environment.Population.Add(individual);
            }
            environment.EvaluateAll();
        }

        /// <summary>
        /// Perform one GA step
        /// </summary>
        public void NextStep()
        {
            environment.MutateAll();
            Population<T> newPopulation = new Population<T>();
            foreach (Individual<T> individual in environment.Population.ToList())
            {
                List<Individual<T>> selected = environment.Select(2);
                Individual<T> offsring = selected[0].Reproduce(selected[1]);
                newPopulation.Add(offsring);
            }
            environment.Population = newPopulation;
            environment.EvaluateAll();
        }
    }
}
