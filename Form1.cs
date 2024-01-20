using System.IO;

namespace Station_Cycle_time_analyzer
{

    public partial class Form1 : Form
    {
        public partial class Product
        {
            public string blockNumber = string.Empty;
            public DateTime signInTimeStamp;
            public DateTime signOutTimeStamp;
        }

        public partial class StationLog
        {
            public string stationName = string.Empty;
            public string logContent = string.Empty;
            public DateTime logDate;

            public StationLog(string stationName)
            {
                this.stationName = stationName;
            }

            public StationLog()
            { /*Empty constructor*/ }
        }

        List<Product> productList = new List<Product>();

        List<StationLog> stationsList = new List<StationLog>
        {
            new StationLog("Station-4"),
            new StationLog("Station-5"),
            new StationLog("Station-6"),
            new StationLog("Station-7"),
            new StationLog("Station-8"),
            new StationLog("Station-9"),
            new StationLog("Station-10"),
            new StationLog("Station-11"),
            new StationLog("Station-12"),
            new StationLog("Station-13"),
            new StationLog("Station-14")
        };

        public Form1()
        {
            InitializeComponent();
            GetLogs(stationsList);
        }

        private List<StationLog> GetLogs(List<StationLog> stationLog)
        {
            foreach (var station in stationLog)
            {
                StreamReader sr = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\log.txt");
            }

            return stationLog;
        }

        private void GetRawLogs_btn_Click(object sender, EventArgs e)
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



                        //product.signOutTimeStamp = 
                        //productList.Add()
                    }
                }

                sr.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Exception: " + exc.Message);
            }
        }

    }
}