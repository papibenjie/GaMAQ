using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    class BoolEvaluator : IEvaluator<List<bool>>
    {
        List<bool> model = new List<bool>();

        public BoolEvaluator(List<bool> model)
        {
            this.model = model;
        }

        public double Evaluate(List<bool> adn)
        {
            double score = 1;
            for (int i = 0; i < adn.Count; i++)
            {
                if (model[i] != adn[i])
                {
                    score++;
                }
            }
            return 1 / score;
        }
    }
}
