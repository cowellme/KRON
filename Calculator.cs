using System;
using System.IO;
using System.Windows.Forms;

namespace KRON
{
    internal class Calculator
    {
        static double[] buf = { 0, 0, 0, 0, 0 };
        static bool check = false;
        static double buy, sell;
        static double max, spreed = 0;
        static double QA = 0.045;

        public static double Ratio(double lastPrice)
        {
            #region Buf
            if (buf[4] != buf[3])
                buf[4] = buf[3];
            if (buf[3] != buf[2])
                buf[3] = buf[2];
            if (buf[2] != buf[1])
                buf[2] = buf[1];
            if (buf[1] != buf[0])
                buf[1] = buf[0];
            if (buf[0] != lastPrice)
                buf[0] = lastPrice;
            #endregion

            #region SL
            while (max >= buf[0] * 1.006)
            {
                max *= 0.999;
            }
            #endregion

            #region K
            double k = (lastPrice + buf[4]) / 2 / lastPrice;
            #endregion

            #region Buy
            if (k >= 1.00035 && !check)
            {
                try
                {
                    buy = lastPrice;
                    check = true;
                    decimal QB = Math.Round((decimal)QA, 5);
                    Binance.Buy("BTCUSDT", QB);
                    Logger.InFileOrderBuy(buy, spreed * QA);

                    TeleLogger.MainT();

                    using (StreamReader str = new StreamReader(Application.StartupPath + @"\Info\Id.txt"))
                    {
                        for (int i = 0; i < File.ReadAllLines(Application.StartupPath + @"\Info\Id.txt").Length; i++)
                        {
                            string chatId = str.ReadLine();
                            Logger.InTeleOrderBuy(lastPrice, spreed * QA, long.Parse(chatId));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
            }

            #endregion

            #region Sell

            if (lastPrice >= buy * 1.0025 && check)
            {
                try
                {
                    sell = lastPrice;
                    spreed = spreed + (sell - buy);
                    check = false;
                    decimal QB = Math.Round((decimal)QA, 5);
                    Binance.Sell("BTCUSDT", QB);
                    Logger.InFileOrderSell(sell, spreed * QA);

                    TeleLogger.MainT();

                    using (StreamReader str = new StreamReader(Application.StartupPath + @"\Info\Id.txt"))
                    {
                        for (int i = 0; i < File.ReadAllLines(Application.StartupPath + @"\Info\Id.txt").Length; i++)
                        {
                            string chatId = str.ReadLine();
                            Logger.InTeleOrderSell(lastPrice, spreed * QA, long.Parse(chatId));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
            }

            if (check)
            {
                max = lastPrice;
            }

            #endregion

            #region End
            Logger.InFile(k, buf[0], buf[4], max);

            return k;
            #endregion
        }
        public static double Angle(double b)
        {
            double a = 200.0;
            int x = (int)a;
            int y = (int)b;

            double gip = Math.Sqrt(a * a + b * b);
            double angel = b / gip;
            
            Logger.InJpgFile(x, y, angel); // Сначала нижний катет, потом высоту 
            return angel;
        }
    }
}
