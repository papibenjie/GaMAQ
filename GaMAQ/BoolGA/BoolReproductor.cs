using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    class BoolReproductor : IReproductor<List<bool>>
    {
        Random rdm = new Random();

        public List<bool> Reproduce(List<bool> adn1, List<bool> adn2)
        {
            List<bool> offspringAdn = new List<bool>();
            for (int i = 0; i < adn1.Count; i++)
            {
                offspringAdn.Add(rdm.NextDouble() < 0.5 ? adn1[i] : adn2[i]);
            }
            return offspringAdn;
        }
    }
}
