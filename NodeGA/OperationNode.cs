using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NodeGA
{
    class OperationNode : Node
    {
        //------------------------------------------------

        public OperationNode(string name, Func<float[], float> func) : base(name, func)
        {

        }
    }
}
