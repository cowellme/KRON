using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;

namespace KRON
{
    internal class TeleLogger
    {
        /// replyMarkup: new InlineKeyboardMarkup(InlineKeyboardButton.WithUrl("Check sendMessage method", "https://core.telegram.org/bots/api#sendmessage")) ⏳ 📈 ⛔️ ℹ️

        static ITelegramBotClient bot = new TelegramBotClient("5393920518:AAGWzwX6OhJfpKjWOY5mzHLzF4i9n1delC8");
        public static string user = "";
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            try
            {
                if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
                {
                    var message = update.Message;
                    
                    if (message.Text.ToLower() == "/start")
                    {
                        user = "/start";

                        await botClient.SendTextMessageAsync(message.Chat, "Ну что смертный, посмотришь как торгует сам ТИТАН KRONOS?");

                        string chatId = message.Chat.Id.ToString();

                        await botClient.SendTextMessageAsync(message.Chat, "Ваш ID " + chatId);

                        var check = 0;

                        using (StreamReader str = new StreamReader(Application.StartupPath + @"\Info\Id.txt"))
                        {
                            for (int i = 0; i < System.IO.File.ReadAllLines(Application.StartupPath + @"\Info\Id.txt").Length; i++)
                            {
                                if (chatId == str.ReadLine())
                                {
                                    check = 1;
                                    break;
                                }
                            }
                            if (check == 0)
                            {
                                System.IO.File.AppendAllText(Application.StartupPath + @"\Info\Id.txt", chatId + Environment.NewLine);
                            }
                        }
                    }


                    if (message.Text == "/stop")
                    {
                        user = "/stop";
                        await botClient.SendTextMessageAsync(message.Chat, "Уведомления отключены, ждем вашего возвращения");
                    }
                        

                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            
        }
        public static void MainT()
        {
            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };

            bot.StartReceiving(HandleUpdateAsync, HandleErrorAsync, receiverOptions, cancellationToken);
        }
    }
}
