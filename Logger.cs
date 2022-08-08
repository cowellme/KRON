using System;
using System.IO;
using Telegram.Bot;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace KRON
{
    internal class Logger
    {
        static ITelegramBotClient bot = new TelegramBotClient("5393920518:AAGWzwX6OhJfpKjWOY5mzHLzF4i9n1delC8");
        public static void Error(Exception exception)
        {
            string date = DateTime.Now.ToString("d - HH:mm:ss:ffff");
            File.AppendAllText(Application.StartupPath + @"\Logs\Errors.txt", exception.Message + "    =>    " + date + Environment.NewLine);
            File.AppendAllText(Application.StartupPath + @"\Logs\Errors.csv", exception.Source + ";" + exception.Message + ";" + date + ";" +Environment.NewLine);
        }
        public static void Info(string text)
        {
            string date = DateTime.Now.ToString("d - HH:mm:ss:ffff");
            File.AppendAllText(Application.StartupPath + @"\Logs\Errors.txt", text + "    =>    " + date + Environment.NewLine);
        }
        public static void InFile(double k, double lastPrice, double unLastPrice, double max)
        {
            string date = DateTime.Now.ToString("d - HH:mm:ss:ffff");
            //0.999977529   19 - 19:03:6024      23141.42          23140.38           23141.42
            File.AppendAllText(Application.StartupPath + @"\Logs\RatioDate.txt", $"{k.ToString("0.000000000")}   {date}      {lastPrice.ToString("0.00")}          {unLastPrice.ToString("0.00")}           {max.ToString("0.00")}" + Environment.NewLine);
            //File.AppendAllText(Application.StartupPath + @"\Logs\RatioDate.txt", k.ToString("0.000000000") + "    =>    " + date + "  Last: " + lastPrice.ToString("0.00") + "  Un last: " + unLastPrice.ToString("0.00") + "  Max: " + max.ToString("0.00") + Environment.NewLine);
            File.AppendAllText(Application.StartupPath + @"\Logs\RatioDate.csv", k.ToString("0.000000000") + ";" + date + ";" + lastPrice.ToString("0.00") + ";" + unLastPrice.ToString("0.00") + ";" + max.ToString("0.00") + Environment.NewLine);
        }
        public static void InFileOrder(double buy, double sell, double max)
        {
            string date = DateTime.Now.ToString("d - HH:mm:ss:ffff");
            File.AppendAllText(Application.StartupPath + @"\Logs\Orders.csv", buy.ToString("0.00") + ";" + sell.ToString("0.00") + ";" + max.ToString("0.00") + ";" + date + Environment.NewLine);
            File.AppendAllText(Application.StartupPath + @"\Logs\Orders.txt", buy.ToString("0.00") + ";" + sell.ToString("0.00") + ";" + max.ToString("0.00") + ";" + date + Environment.NewLine);
        }
        public static void InFileOrderBuy(double price, double spreed)
        {
            string date = DateTime.Now.ToString("d - HH:mm:ss:ffff");
            File.AppendAllText(Application.StartupPath + @"\Logs\Orders.csv", "Bougt => " + price.ToString("0.00") + ";" + spreed.ToString("0.00") + ";" + date + Environment.NewLine);
            File.AppendAllText(Application.StartupPath + @"\Logs\Orders.txt", "Купил по " + price.ToString("0.00") + " в " + DateTime.Now.ToString("HH:mm:ff") + Environment.NewLine);
        }
        public static void InFileInduc(double A, double B)
        {
            string date = DateTime.Now.ToString("d - HH:mm:ss:ffff");
            File.AppendAllText(Application.StartupPath + @"\Logs\Induc.txt", "A = " + A.ToString("0.00") + "B = " + B.ToString("0.00") + "        " + date + Environment.NewLine);
        }
        public static void InFileOrderSell(double prcie, double spreed)
        {
            try
            {
                string date = DateTime.Now.ToString("d - HH:mm:ss:ffff");
                File.AppendAllText(Application.StartupPath + @"\Logs\Orders.csv", "Sell  => " + prcie.ToString("0.00") + ";" + spreed.ToString("0.00") + ";" + date + Environment.NewLine);
                File.AppendAllText(Application.StartupPath + @"\Logs\Orders.txt", "Продал по " + prcie.ToString("0.00") + " Заработал: " + spreed.ToString("0.00") + " в " + DateTime.Now.ToString("HH:mm:ff") + Environment.NewLine);

            }
            catch
            {

            }
        }                                                                   
        public static void InTeleOrderSell(double price, double spreed, long chatId)
        {
            try
            {
                string date = DateTime.Now.ToString("HH:mm:ss");
                bot.SendTextMessageAsync(chatId: chatId, text: $"❌ Продал BTC по {price}$ \n══════════════════\nЗаработал {(spreed * 0.92).ToString("0.00")}$ 📈 \n══════════════════\nВ {date} MCK").Wait();
            }
            catch
            {

            }
        }                                                  
        public static void InTeleOrderBuy(double price, double spreed, long chatId)
        {
            try
            {
                string date = DateTime.Now.ToString("HH:mm:ss");
                bot.SendTextMessageAsync(chatId: chatId, text: $"✅ Купил BTC по {price}$ \n══════════════════\nВ {date} MCK").Wait();
            }
            catch
            {

            }
        }
        public static void InJpgFile(int x, int y, double angel)
        {
            string date = DateTime.Now.ToString("d.HH.mm");
            Point a = new Point(10, 100);
            Point b = new Point(x + 10, 100);
            Point c = new Point(x + 10, 100 - y);
            Pen pen = new Pen(Color.Black, 3);

            var bitMap = new Bitmap(210, 210);
            using (var g = Graphics.FromImage(bitMap))
            {
                g.Clear(Color.White);
                g.DrawLine(pen, a, b);
                g.DrawLine(pen, b, c);
                g.DrawLine(pen, c, a);
            }
            bitMap.Save(Application.StartupPath + @$"/Info/Angel/" + date + "Angel.jpeg", ImageFormat.Jpeg);

            File.AppendAllText(Application.StartupPath + @$"/Info/" + date + ".txt", $"A = {a}, B = {b}, angel = {angel}"  + Environment.NewLine);
        }
    }
}