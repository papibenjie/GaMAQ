using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    class DivNode : Node
    {
        public DivNode() : base("DIV")
        {
        }

        protected override double run(List<double> vars)
        {
            return vars[0] / vars[1];
        }
    }
}
