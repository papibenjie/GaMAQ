using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    /// <summary>
    /// Evaluator interface
    /// </summary>
    /// <typeparam name="T">The type of dna to evaluate</typeparam>
    public interface IEvaluator<T>
    {
        /// <summary>
        /// Evaluate dna and return a score.
        /// </summary>
        /// <param name="dna">The dna to evaluate.</param>
        /// <returns>The score</returns>
        double Evaluate(T dna);
    }
}
