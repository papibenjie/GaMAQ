using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    /// <summary>
    /// Generator interface
    /// </summary>
    /// <typeparam name="T">The type of dna to generate</typeparam>
    public interface IGenerator<T>
    {
        /// <summary>
        /// Generate random dna.
        /// </summary>
        /// <returns>dna created</returns>
        T Generate();
    }
}
