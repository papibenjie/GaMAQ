using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaMAQ
{
    class ConstNode : Node
    {
        private double value = 0;

        public ConstNode(double value) : base(value.ToString())
        {
            this.value = value;
        }

        protected override double run(List<double> vars)
        {
            return value;
        }
    }
}
