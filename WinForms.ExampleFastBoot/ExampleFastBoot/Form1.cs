using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExampleFastBoot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            var sw = Stopwatch.StartNew();
            
            InitializeComponent();

            // This is slow load.
            //MakeSomeLongOperation(4);
            //Load += Form1_Load;

            // This is fast load.
            Task.Run(() =>
            {
                MakeSomeLongOperation(4);
                Load += Form1_Load;
            });

            labelLoad.Text = "Form load time: " + sw.Elapsed.ToString();
            sw.Stop();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
        }

        private void MakeSomeLongOperation(int seconds)
        {
            // Make some long operation.
            for (int i = 0; i < seconds * 100; i++)
            {
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
