using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ArkDiscord.Modules
{
    public class Snail : ModuleBase<SocketCommandContext>
    {

        private Timer _snailTimer;

        [Command("snails")]

        public async Task snailTimer()
        {
  
            await ReplyAsync("Snail timer has been set!");
            _snailTimer = new Timer(snailTimerCallback, Context, 1000 * 60 * 100, 0); 
        }

        private void snailTimerCallback(object obj)
        {
            SocketCommandContext context = obj as SocketCommandContext;
            context.Channel.SendMessageAsync(context.User.Mention + " Snails can be looted!");
            _snailTimer.Dispose();
        }


    }
}
