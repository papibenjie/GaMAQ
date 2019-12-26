using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    public interface IGenerator<T>
    {
        /// <summary>
        /// Generate random dna.
        /// </summary>
        /// <returns>dna created</returns>
        T Generate();
    }
}
