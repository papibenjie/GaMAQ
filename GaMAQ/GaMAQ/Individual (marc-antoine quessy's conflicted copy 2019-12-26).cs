using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    /// <summary>
    /// Class representing an individual.
    /// Contains Dna and operators to use it.
    /// </summary>
    /// <typeparam name="T">The type of the dna</typeparam>
    public class Individual<T>
    {
        private IMutator<T> mutator;
        private IReproductor<T> reproductor;

        public double Fitness { get; set; } = 0;
        public T Dna { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mutator">Individual mutator</param>
        /// <param name="reproductor">Individual reproductor</param>
        /// <param name="dna">Individual base dna</param>
        public Individual(IMutator<T> mutator, IReproductor<T> reproductor, T dna)
        {
            this.mutator = mutator;
            this.reproductor = reproductor;
            this.Dna = dna;
        }

        /// <summary>
        /// Mutate the Dna using the mutator
        /// </summary>
        public void Mutate()
        {
            T adn = Dna;
            mutator.Mutate(ref adn);
            Dna = adn;
        }

        /// <summary>
        /// Create a new individual combining 2 individuals
        /// </summary>
        /// <param name="mate">The mate to reproduce with</param>
        /// <returns>The offspring created</returns>
        public Individual<T> Reproduce(Individual<T> mate)
        {
            T offspringAdn = reproductor.Reproduce(Dna, mate.Dna);
            return new Individual<T>(mutator, reproductor, offspringAdn);
        }
    }
}
