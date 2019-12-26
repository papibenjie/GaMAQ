
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeGA
{
    class Program
    {
        static void Main(string[] args)
        {
            NodeGenerator generator = new NodeGenerator(3, 5, new List<float> { 1, 2, 3, 4, 5 });
            Tree tree = generator.Generate();

            tree.PrintTree();

            Console.Read();
        }
    }
}
