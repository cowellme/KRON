using System;
using Binance.API.Csharp.Client;
using Binance.API.Csharp.Client.Models.Enums;

namespace KRON
{
    public class Binance
    {
        public static ApiClient apiClient = null;
        public static BinanceClient binanceClient = null;
        static double[] buf = { 0, 0};
        static bool check = true;
        public static void Connect(string API, string APIS)
        {
            try
            {
                apiClient = new ApiClient(API, APIS);
                binanceClient = new BinanceClient(apiClient, false);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        public static double ParseCost(string API, string APIS, string name)
        {
            
            try
            {
                
                var para = binanceClient.GetAggregateTrades(name, 1).Result;
                string response = System.Text.Json.JsonSerializer.Serialize(para);
                response = System.Text.RegularExpressions.Regex.Match(response, "\"Price\":(.*),\"Quantity\":").Groups[1].Value;
                double cost = Convert.ToDouble(response);

                if (DateTime.Now.ToString("mm") == "00" && check)
                {
                    if (buf[1] != buf[0])
                        buf[1] = buf[0];
                    if (buf[0] != cost)
                        buf[0] = cost;
                    check = false;
                    
                    if (buf[0] != 0.0 && buf[1] != 0.0)
                    {
                        Calculator.Angle(buf[0] - buf[1]);
                    }
                }

                if (DateTime.Now.ToString("mm") == "10" && !check)
                {
                    Logger.Info("check = true");
                    check = true;
                }

                return cost;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return 0.0;
            }
        }
        public static void Buy(string name, decimal quantity)
        {
            try
            {
                var buyMarketOrder = binanceClient.PostNewOrder(name, quantity, 0m, OrderSide.BUY, OrderType.MARKET).Result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        public static void Sell(string name, decimal quantity)
        {
            try
            {
                var sellMarketOrder = binanceClient.PostNewOrder(name, quantity, 0m, OrderSide.SELL, OrderType.MARKET).Result;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}
