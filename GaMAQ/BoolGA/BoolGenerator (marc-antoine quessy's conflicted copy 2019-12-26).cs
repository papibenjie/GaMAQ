using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    class BoolGenerator : IGenerator<List<bool>>
    {
        private int size;
        private Random rdm = new Random();

        public BoolGenerator(int size)
        {
            this.size = size;
        }

        public List<bool> Generate()
        {
            List<bool> adn = new List<bool>();
            for (int i = 0; i < size; i++)
            {
                adn.Add(rdm.NextDouble() < 0.5 ? true : false);
            }
            return adn;
        }
    }
}
