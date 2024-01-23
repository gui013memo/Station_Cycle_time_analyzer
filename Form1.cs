using Microsoft.Win32.SafeHandles;
using System.Security.Principal;
using SimpleImpersonation;
using System.Runtime.InteropServices;

namespace Station_Cycle_time_analyzer
{

    //concept -> a client in each station that after a master requisition insert on a SQL Server table the data with the inserted parameters: // * ONE REQ AT A TIME *!
    //date, station, signInTime, signOfTime
    //


    public partial class Form1 : Form
    {
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);


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

        string sourceFile = string.Empty;

        public Form1()
        {



            InitializeComponent();
            //GetStationLogs(stationsList);
            monthCalendar1.MaxSelectionCount = 1;
        }

        // =================================== myFunctions =================================== //

        private List<StationLog> GetStationLogs(List<StationLog> stationLog)
        {
            foreach (var station in stationLog)
            {
                StreamReader sr = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\log.txt");
            }

            return stationLog;
        }

        private StationLog GetStationLog(StationLog stationLog)
        {
            // \\station-4\ApplicationLogs\ProuductSignInUI
            //log-20240117

            textBox1.Text += "Station Name: " + stationLog.stationName;
            string date = monthCalendar1.SelectionRange.Start.ToString("yyyyMMdd");
            date = date.Replace("/", "");

            string path = "\\\\" + stationLog.stationName + "\\ApplicationLogs" + "\\ProuductSignInUI" + "\\" + "log-" + date;
            sourceFile = path;

            return stationLog;
        }



        private void GetRawLogs_btn_Click(object sender, EventArgs e)
        {
            //StationLog s1 = stationsList.Find(x => x.stationName == "Station-4");
            //s1 = GetStationLog(stationsList.Find(x => x.stationName == "Station-5"));

            //UserCredentials credentials = new UserCredentials("GMESEP\\admin");



            try
            {
                LogonUser("\\admin", "GMESEP", "", 2, 1, out var phToken);
                SafeAccessTokenHandle userHandle = new SafeAccessTokenHandle(phToken);

                WindowsIdentity.RunImpersonated(userHandle, () =>
                {
                    sourceFile = @"\\station-5\ApplicationLogs\ProuductSignInUI\log-20240120.log";
                    string destinationFile = @"C:\AtlasCopco\CopyTST1.txt";

                    try
                    {
                        File.Copy(sourceFile, destinationFile, true);
                        MessageBox.Show("IT WORKED OUT!1111");
                    }
                    catch (IOException iox)
                    {
                        MessageBox.Show(iox.Message);
                    }

                    MessageBox.Show("IT WORKED OUT!2");
                });
            }
            catch (Exception iox)
            {
                MessageBox.Show(iox.Message);
            };

            







            //String line = string.Empty;
            //try
            //{
            //    StreamReader sr = new StreamReader(System.IO.Directory.GetCurrentDirectory() + "\\log.txt");

            //    line = sr.ReadLine();

            //    textBox1.Text = line;

            //    while (line != null)
            //    {
            //        line = sr.ReadLine();
            //        if (line.Contains("Barcode step 4/4"))
            //        {
            //            Product product = new Product();

            //            product.signInTimeStamp = DateTime.Parse(line.Substring(0, 13));
            //            textBox1.Text = product.signInTimeStamp.ToLongTimeString();

            //            product.blockNumber = line.Substring(line.IndexOf(",\"Barcode\":\"B"), 25);
            //            textBox1.Text = product.blockNumber;
            //            textBox1.Text = product.blockNumber;



            //            //product.signOutTimeStamp = 
            //            //productList.Add()
            //        }
            //    }

            //    sr.Close();
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show("Exception: " + exc.Message);
            //}
        }

    }
}