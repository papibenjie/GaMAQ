using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    /// <summary>
    /// Mutator interface
    /// </summary>
    /// <typeparam name="T">The type of dna to mutate</typeparam>
    public interface IMutator<T>
    {
        /// <summary>
        /// change dna with a low probability
        /// </summary>
        /// <param name="dna"></param>        
        void Mutate(ref T dna);
    }
}
