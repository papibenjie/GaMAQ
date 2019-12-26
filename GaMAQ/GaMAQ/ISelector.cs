using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    public interface ISelector<T>
    {
        /// <summary>
        /// Select an individual in the population
        /// </summary>
        /// <param name="population">The population of individuals</param>
        /// <returns>The individual selected</returns>
        Individual<T> Select(Population<T> population);
    }
}
