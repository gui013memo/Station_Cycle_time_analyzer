using Microsoft.Win32.SafeHandles;
using System.Security.Principal;
using SimpleImpersonation;
using System.Runtime.InteropServices;
using CsvHelper;
using System.Globalization;

namespace Station_Cycle_time_analyzer
{

    //concept -> a client in each station that after a master requisition insert on a SQL Server table the data with the inserted parameters: // * ONE REQ AT A TIME *!
    //date, station, signInTime, signOfTime
    //


    public partial class Form1 : Form
    {
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, out IntPtr phToken);

        public class CsvExport
        {
            public string iD { get; set; }
            public string station { get; set; }
            public string signIn { get; set; }

            public string signOf { get; set; }
        }

        public partial class Product
        {
            public string blockNumber = string.Empty;
            public string stationName = string.Empty;
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
            new StationLog("Station-H1"),
            new StationLog("Station-H2"),
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

        List<CsvExport> records = new List<CsvExport> { };

        string station = "OP20M1";

        public Form1()
        {
            InitializeComponent();

        }

        // =================================== myFunctions =================================== //



        private void GetRawLogs_btn_Click(object sender, EventArgs e)
        {
            String line = string.Empty;
            bool productFoundMemory = false;


            try
            {
                int i = 0;
                int j = 0;

                using (StreamReader sr = new StreamReader("C:\\Gui\\CsvExporter-22-01\\" + station + "\\log-20240122.log"))
                {
                    string blockNumber = "";
                    string stationName = "";
                    DateTime signInTimeStamp = new DateTime();
                    DateTime signOutTimeStamp = new DateTime();


                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!productFoundMemory && line.Contains("Barcode step 4/4"))
                        {
                            i++;
                            productFoundMemory = true;

                            blockNumber = line.Substring(line.IndexOf(",\"Barcode\":\"B") + 12, 13);
                            // textBox1.Text += "\r\n" + blockNumber;

                            stationName = line.Substring(line.IndexOf("StationHostName") + 15, 13);
                            stationName = stationName.Replace("\"", "");
                            stationName = stationName.Replace(":", "");
                            // textBox1.Text += "\r\n" + stationName;

                            signInTimeStamp = DateTime.Parse(line.Substring(0, 13));
                            // textBox1.Text += "\r\n" + signInTimeStamp.ToString("HH:mm:ss:");
                        }

                        if (productFoundMemory && line.Contains("\"WsMsgType\":\"StationSignInReturn\""))
                        {
                            j++;
                            signOutTimeStamp = DateTime.Parse(line.Substring(0, 13));
                            // textBox1.Text += "\r\n" + signOutTimeStamp.ToString("HH:mm:ss:");

                            signInTimeStamp = DateTime.ParseExact("2024-01-22 " + signInTimeStamp.ToString("HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                            signOutTimeStamp = DateTime.ParseExact("2024-01-22 " + signOutTimeStamp.ToString("HH:mm:ss"), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                            records.Add(new CsvExport { iD = blockNumber, station = stationName, signIn = signInTimeStamp.ToString("yyyy MM dd HH:mm:ss"), signOf = signOutTimeStamp.ToString("yyyy MM dd HH:mm:ss") }); ;

                            productFoundMemory = false;
                        }



                    }
                }

                textBox1.Text += "The logs were collected -> " + i.ToString() + "signIns / " + j.ToString() + "SignOfs";
            }
            catch (Exception exc)
            {
                MessageBox.Show("Exception: " + exc.Message);
            }
        }

        private void ExportCSV_btn_Click(object sender, EventArgs e)
        {
            string path = "C:\\Gui\\CsvExporterOut\\export" + station + ".csv";
            try
            {
                using (var writer = new StreamWriter(path))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);
                }

                textBox1.Text += "\r\nExported to path:\r\n" + path;
                records.Clear();
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
        }
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

            return stationLog;
        }

        private string FormatLog(string logContent)
        {


            return logContent;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            station = textBox2.Text;
        }
    }
}