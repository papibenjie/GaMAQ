using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    class Environment<T>
    {
        private ISelector<T> selector;
        private IEvaluator<T> evaluator;
        public Population<T> Population { get; set; }

        public Environment(ISelector<T> selector, IEvaluator<T> evaluator)
        {
            this.selector = selector;
            this.evaluator = evaluator;
            Population = new Population<T>();
        }

        public void EvaluateAll()
        {
            foreach (Individual<T> individual in Population)
            {
                individual.Fitness = evaluator.Evaluate(individual.Dna);
            }
        }

        public void MutateAll()
        {
            foreach (Individual<T> individual in Population)
            {
                individual.Mutate();
            }
        }

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
