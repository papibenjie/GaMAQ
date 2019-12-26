using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    class GeneticAlgorithm<T>
    {
        private IEvaluator<T> evaluator;
        private IGenerator<T> generator;
        private ISelector<T> selector;

        private Environment<T> environment;

        public GeneticAlgorithm(IEvaluator<T> evaluator, IGenerator<T> generator, ISelector<T> selector)
        {
            this.evaluator = evaluator;
            this.generator = generator;
            this.selector = selector;

            environment = new Environment<T>(selector, evaluator);
        }

        public Individual<T> GetBest()
        {
            return environment.Population.GetBest();
        }

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
