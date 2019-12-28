using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    class SubNode : Node
    {
        public SubNode() : base("SUB")
        {
        }

        protected override double run(List<double> vars)
        {
            return vars[0] - vars[1];
        }
    }
}
