using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGA
{
    class ConstNode : Node
    {
        public ConstNode(int val) : base(val.ToString(), v => val)
        {

        }
    }
}
