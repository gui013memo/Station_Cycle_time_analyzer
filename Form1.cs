using System.IO;

namespace Station_Cycle_time_analyzer
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public partial class Product
        {
            public string blockNumber = string.Empty;
            public DateTime signInTimeStamp;
            public DateTime signOutTimeStamp;
        }

        List<Product> productList = new List<Product>();

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
                    line = sr.ReadLine();
                    if (line.Contains("Barcode step 4/4"))
                    {
                        Product product = new Product();
                        
                        product.signInTimeStamp = DateTime.Parse(line.Substring(0, 13));
                        textBox1.Text = product.signInTimeStamp.ToLongTimeString();

                        product.blockNumber = line.Substring(line.IndexOf(",\"Barcode\":\"B"), 25);
                        textBox1.Text = product.blockNumber;
                        textBox1.Text = product.blockNumber;


                        //productList.Add()
                    }
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