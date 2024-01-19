using System.IO;

namespace Station_Cycle_time_analyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String line = string.Empty;
            try
            {
                StreamReader sr = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\log.txt");

                line = sr.ReadLine();

                textBox1.Text = line;

                while (line != null) 
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }

                sr.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Exception: " + exc.Message);
            }
        }
    }
}