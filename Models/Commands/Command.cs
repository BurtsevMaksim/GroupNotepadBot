using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using GroupNotepad.Support_Classes;
using Telegram.Bot.Types;

namespace GroupNotepad.Models.Commands
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract Task Execute(Message message, TelegramBotClient client);

        public abstract bool Contains(Message message);
    }
}
