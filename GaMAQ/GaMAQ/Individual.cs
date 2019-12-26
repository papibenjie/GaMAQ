using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    public class Individual<T>
    {
        private IMutator<T> mutator;
        private IReproductor<T> reproductor;

        public double Fitness { get; set; } = 0;
        public T Dna { get; set; }

        public Individual(IMutator<T> mutator, IReproductor<T> reproductor, T adn)
        {
            this.mutator = mutator;
            this.reproductor = reproductor;
            this.Dna = adn;
        }

        public void Mutate()
        {
            T adn = Dna;
            mutator.Mutate(ref adn);
            Dna = adn;
        }

        public Individual<T> Reproduce(Individual<T> mate)
        {
            T offspringAdn = reproductor.Reproduce(Dna, mate.Dna);
            return new Individual<T>(mutator, reproductor, offspringAdn);
        }
    }
}
