using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGA
{
    class Node
    {
        public Func<float[], float> Func { get; set; }
        public string Name { get; set; } = "NONAME";

        public List<Node> Children { get; set; }

        public float Compute()
        {
            float[] vals = Children.Select(n => n.Compute()).ToArray();
            return Func(vals);
        }

        public override string ToString()
        {
            return String.Format("{0}({1})", Name, Compute());
        }
    }
}
