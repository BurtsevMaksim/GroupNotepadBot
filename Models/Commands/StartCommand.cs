using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace GroupNotepad.Models.Commands
{
    public class StartCommand : Command
    {
        private readonly string Greeting = "Over here, stranger! I've got something that might interested ya.";
        public override string Name => @"/start";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return false;
            }
            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, Greeting, parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
