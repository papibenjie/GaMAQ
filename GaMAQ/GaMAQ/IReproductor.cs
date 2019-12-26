using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    public interface IReproductor<T>
    {
        /// <summary>
        /// Combine 2 dna to create a new one.
        /// </summary>
        /// <param name="dna1">first dna</param>
        /// <param name="dna2">second dna</param>
        /// <returns>dna created</returns>
        T Reproduce(T dna1, T dna2);
    }
}
