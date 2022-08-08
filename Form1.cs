using System;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace KRON
{
    public partial class KRON : Form
    {
        ///"RE30kVH5LTEzOrj4l2RdtcxBxB5IozHSMxskPEIS1fMzJnwXQBXhh0oLlKUBNddF", "CVzW1DnjJauM0VHAWbj03KBXCoR73XU5GPbRATMJebirqzqGeYrjTaveSRNEzIvx"
        ///Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Kronos\KRONOS\Database.mdf;Integrated Security=True

        bool drag = false;
        int checkMinute = 0;
        int checkHalfHour = 0;
        double Angel = 0.0;
        public double lastPrice;
        double[] points = { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 ,0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
        Point startPoint = new Point(0, 0);

        const string name = "BTCUSDT";
        const string API = "Drwi5BuH8UbEwqkICpCnc8MOqynUpuVo8l1LFo9R3jQwmhhoD7I8RzmGMsMEOYav";
        const string APIS = "dmaHRQKpotv0Waw0G32AyvLa1nNwz0MFHMtvMyoW8WXU6dESionW7ggg4yre0871";

        private static SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString);

        public KRON()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.label1.Text = "version: " + File.ReadAllText(Application.StartupPath + @"\Info\Version.txt");
                File.AppendAllText(Application.StartupPath + @"\Logs\Errors.csv", "Path" + ";" + "Message" + ";" + "Data" + ";" + Environment.NewLine);
                File.AppendAllText(Application.StartupPath + @"\Logs\Orders.csv", "Price Buy" + ";" + "Price Sell" + ";" + "Price Max" + ";" + "Date" + Environment.NewLine);
                File.AppendAllText(Application.StartupPath + @"\Logs\RatioDate.csv", "Ratio" + ";" + "Data" + ";" + "Last Price" + ";" + "Un Last Price" + ";" + "Masx Price" + Environment.NewLine);
                File.AppendAllText(Application.StartupPath + @"\Logs\Errors.txt", "Path" + "   |   " + "Message" + "   |   " + "Data" + "   |   " + Environment.NewLine);
                File.AppendAllText(Application.StartupPath + @"\Logs\Orders.txt", "Бот подключен" + Environment.NewLine);
                File.AppendAllText(Application.StartupPath + @"\Logs\RatioDate.txt", "Ratio" + "        |       " + "Data" + "     |   " + "Last Price" + "   |   " + "Un Last Price" + "   |   " + "Masx Price" + Environment.NewLine);
                
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        public async void Algoritm()
        {
            await Task.Run(() => 
            {

                TeleLogger.MainT();
                Binance.Connect(API, APIS);

                while (true)
                {
                    Thread.Sleep(10000);
                    checkMinute++;
                    lastPrice = Binance.ParseCost(API, APIS, name);
                    string ratio = Calculator.Ratio(lastPrice).ToString("0.000000");

                    try 
                    {
                        if (checkMinute >= 6)
                        {
                            checkMinute = 0;
                            checkHalfHour++;
                            #region Angle
                            points[29] = points[28];
                            points[28] = points[27];
                            points[27] = points[26];
                            points[26] = points[25];
                            points[25] = points[24];
                            points[24] = points[23];
                            points[23] = points[22];
                            points[22] = points[21];
                            points[21] = points[20];
                            points[20] = points[19];
                            points[19] = points[18];
                            points[18] = points[17];
                            points[17] = points[16];
                            points[16] = points[15];
                            points[15] = points[14];
                            points[14] = points[13];
                            points[13] = points[12];
                            points[12] = points[11];
                            points[11] = points[10];
                            points[10] = points[9];
                            points[9] = points[8];
                            points[8] = points[7];
                            points[7] = points[6];
                            points[6] = points[5];
                            points[5] = points[4];
                            points[4] = points[3];
                            points[3] = points[2];
                            points[2] = points[1];
                            points[1] = points[0];
                            points[0] = lastPrice;
                            #endregion

                            if (checkHalfHour >= 30)
                            {
                                checkHalfHour = 40;
                                Angel = Calculator.Angle(points[29] - lastPrice);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Logger.Error(ex);
                    }

                    Invoke((Action)(() => { textBox1.Text = $"K = {ratio}  Angle = {Angel:0.000}"; }));
                }
            });
        }

        #region BotPanel
        private void Start_Click(object sender, EventArgs e)
        {
            Algoritm();
        }
        #endregion
        #region TopPanel
        #region Hover
        private void TopPanel_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                drag = true;
                startPoint = new Point(e.X, e.Y);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        private void TopPanel_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (drag)
                {
                    Point p = PointToScreen(e.Location);
                    this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

        private void TopPanel_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                drag = false;
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void Closer_Click(object sender, EventArgs e)
        {
            string ver = File.ReadAllText(Application.StartupPath + @"\Info\Version.txt");
            ver = System.Text.RegularExpressions.Regex.Match(ver, "......([0-9])").Groups[1].Value;
            
            int v = Convert.ToInt32(ver);
            v++;
            ver = v.ToString();
            File.WriteAllText(Application.StartupPath + @"\Info\Version.txt", $"1.0.0.{ver}");
            Application.Exit();
        }

        #endregion
        #region Blank elements
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
