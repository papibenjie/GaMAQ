using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaMAQ
{
    public partial class ImageViewer : Form
    {
        private IEvaluator<List<bool>> evaluator;
        private IGenerator<List<bool>> generator = new BoolGenerator(400);
        private IMutator<List<bool>> mutator = new BoolMutator(0.001, 0.0);
        private IReproductor<List<bool>> reproductor = new BoolReproductor();
        private ISelector<List<bool>> selector = new BoolSelector();

        private GeneticAlgorithm<List<bool>> GA;

        Bitmap bmp = new Bitmap(20, 20);

        public ImageViewer()
        {
            List<bool> model = new List<bool>();
            for (int i = 0; i < 400; i++)
            {
                model.Add(i%2 == 0 ? true : false);
            }

            evaluator = new BoolEvaluator(model);
            InitializeComponent();
         //   GA = new GeneticAlgorithm<List<bool>>(evaluator, generator, mutator, reproductor, selector);
        //    GA.initialize(100);

            pictureBox1.Size = new Size(20, 20);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            GA.NextStep();

            Individual<List<bool>> best = GA.GetBest();

            for (int j = 0; j < best.Dna.Count; j++)
            {
                bmp.SetPixel(j / 20, j % 20, (best.Dna[j] ? Color.Black : Color.White));
            }

            pictureBox1.Image = bmp;
           // Refresh();
            Update();
        }
    }
}
