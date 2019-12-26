using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    class BoolMutator : IMutator<List<bool>>
    {
        private double mutateRate;
        private double selfMutateRate;
        private Random rdm = new Random();

        public BoolMutator(double mutateRate, double selfMutateRate)
        {
            this.mutateRate = mutateRate;
            this.selfMutateRate = selfMutateRate;
        }

        public void Mutate(ref List<bool> adn)
        {
            if(rdm.NextDouble() < selfMutateRate)
            {
                mutateRate += (rdm.NextDouble() < 0.5 ? rdm.NextDouble() / 1000 : -rdm.NextDouble() / 1000);
                if (mutateRate < 0) { mutateRate = 0; }
                else if (mutateRate > 1) { mutateRate = 1; }
            }
            for (int i = 0; i < adn.Count; i++)
            {
                if(rdm.NextDouble() < mutateRate)
                {
                    adn[i] = !adn[i];
                }
            }
        }
    }
}
