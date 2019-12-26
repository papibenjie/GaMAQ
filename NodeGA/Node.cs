using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGA
{
    public class Node
    {
        public Func<float[], float> Func { get; set; }
        public string Name { get; set; } = "NONAME";

        public List<Node> Children { get; set; } = new List<Node>();

        public Node(string name, Func<float[], float> func)
        {
            Func = func;
            Name = name;
        }

        public float Compute()
        {
            float[] vals = Children.Select(n => n.Compute()).ToArray();
            return Func(vals);
        }

        public void PrintTree(int depth)
        {
            for (int i = 0; i < depth; i++)
            {
                Console.Write("----");
            }
            Console.WriteLine(ToString());

            Children.ForEach(child => child.PrintTree(depth + 1));
        }

        public override string ToString()
        {
            return String.Format("{0}({1})", Name, Compute());
        }
    }
}
