using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    class AddNode : Node
    {
        public AddNode() : base("ADD")
        {
        }

        protected override double run(List<double> vars)
        {
            return vars[0] + vars[1];
        }
    }
}
