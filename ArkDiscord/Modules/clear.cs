using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkDiscord.Modules
{
    public class clear : ModuleBase<SocketCommandContext>
    {

        [Command("clear")]
        [Summary("Clear an amount of messages in the channel")]
        [RequireBotPermission(GuildPermission.ManageMessages)]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task ClearMessage([Remainder] int x = 0)
        {
            if (x <= 100)
            {
                var messagesToDelete = await Context.Channel.GetMessagesAsync(x + 1).Flatten();
                await Context.Channel.DeleteMessagesAsync(messagesToDelete);
                if (x == 1)
                {
                    await Context.Channel.SendMessageAsync($"`{Context.User.Username} deleted 1 message`");

                }
                else
                {
                    await Context.Channel.SendMessageAsync($"`{Context.User.Username} deleted {x} messages");
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync("you cannot delete more than 100 messages");
            }
        }

    }
}
