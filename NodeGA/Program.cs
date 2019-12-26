using GaMAQ.NodeGA;
using GaMAQ.Nodes;
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
            NodeGenerator generator = new NodeGenerator(0.5, new List<double> { 1, 2, 3, 4 }, 3, 5);

            NodeMutator mutator = new NodeMutator(0.1, generator);

            NodeReproductor reproductor = new NodeReproductor();

            Tree root1 = generator.Generate();
            Tree root2 = generator.Generate();

            //Console.WriteLine(root.compute().ToString());

            root1.printTree();
            Console.WriteLine("///////////////////////////////////");
            root2.printTree();

            Console.WriteLine("///////////////////////////////////");
            Tree offspring = reproductor.Reproduce(root1, root2);

            offspring.printTree();

            Console.ReadLine();

            //ImageViewer image = new ImageViewer();
            //Application.Run(image);
        }
    }
}
