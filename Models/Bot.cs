using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using GroupNotepad.Support_Classes;
using GroupNotepad.Models.Commands;

namespace GroupNotepad.Models
{
    public static class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandsList = new List<Command>();
            commandsList.Add(new StartCommand());
            //TODO: Add more commands

            botClient = new TelegramBotClient(Appsettings.Key);
            string hook = string.Format(Appsettings.Url, "api/message/update");
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }
    }
}
