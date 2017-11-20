using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkDiscord.Modules
{
    public class chicken : ModuleBase<SocketCommandContext>
    {
        [Command("chicken")]
        public async Task Chickenattack()
        {
            await Context.Channel.SendMessageAsync(Context.User.Mention + " https://www.youtube.com/watch?v=miomuSGoPzI");
        }
    }
}
