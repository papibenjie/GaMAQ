using GaMAQ.NodeGA;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaMAQ
{
    class Program
    {
        static void Main(string[] args)
        {
            NodeGenerator generator = new NodeGenerator(0.3, new List<double> { 1, 2, 3, 4 });

            Node root = generator.generate();

            Console.WriteLine(root.compute().ToString());

            root.printTree();

            Console.ReadLine();

            //ImageViewer image = new ImageViewer();
            //Application.Run(image);
        }
    }
}



