using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkDiscord.Modules
{
    public class ImprintService : System.Timers.Timer
    {

        public readonly string name;
        public readonly int minutes;
        public readonly object Context;


        public ImprintService (string name, int minutes, object context)
        {
            this.name = name;
            this.Context = context;
            this.minutes = minutes;
        } 

    }


    public class Imprint : ModuleBase<SocketCommandContext>
    {
        [Command("imprint")]
        [Summary("Use imprint {name} {time minutes}")]
        public async Task newImprint(string name, int minutes)
        {
            var timer = new ImprintService(name, minutes, Context);
            timer.Interval = 1000 * 60 * minutes;
            timer.Elapsed += ImprintNotification;
            timer.AutoReset = false;
            timer.Start();
            await Context.Channel.SendMessageAsync(Context.User.Mention + "Timer has been start for: " + minutes + " minutes");
        }


        static void ImprintNotification(object sender, EventArgs args)
        {
            ImprintService timer = sender as ImprintService;
            SocketCommandContext context = timer.Context as SocketCommandContext;
            context.Channel.SendMessageAsync(context.User.Mention + "Your " + timer.name + " is ready to imprint!");
        }
    }
}
