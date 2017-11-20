using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArkDiscord.Modules
{
    public class serverinfo : ModuleBase<SocketCommandContext>
    {

        [Command("serverinfo")]
        
        public async Task getServerInfo ()
        {
            string serverInfo = CallRestMethod("https://api.battlemetrics.com/servers/1089092");
            WebClient client = new WebClient();
            String downloadedString = client.DownloadString("https://api.battlemetrics.com/servers/1089092");


            JObject data = JObject.Parse(downloadedString);
            string serverId = (string)data["data"]["id"];
            string serverName = (string)data["data"]["attributes"]["name"];
            string serverIp = (string)data["data"]["attributes"]["ip"];
            string serverPort = (string)data["data"]["attributes"]["port"];
            string serverPlayers = (string)data["data"]["attributes"]["players"];
            string serverMaxPlayers = (string)data["data"]["attributes"]["maxPlayers"];

            var builder = new EmbedBuilder();

            builder.WithTitle("Server information:");
            builder.AddInlineField("ServerID", serverId);
            builder.AddInlineField("ServerName", serverName);
            builder.AddInlineField("ServerIp", serverIp + ":" + serverPort);
            builder.AddInlineField("serverPlayers", serverPlayers + "/" + serverMaxPlayers);
            builder.WithColor(Color.Red);

            await Context.Channel.SendMessageAsync("", false, builder);
        }

        public static string CallRestMethod(string url)
        {
            HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            HttpWebResponse webresponse = (HttpWebResponse)webrequest.GetResponse();
            Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            StreamReader responseStream = new StreamReader(webresponse.GetResponseStream(), enc);
            string result = string.Empty;
            result = responseStream.ReadToEnd();
            webresponse.Close();

            JObject data = JObject.Parse(result);
            string serverId = (string)data["data"]["id"];
            string serverName = (string)data["data"]["attributes"]["name"];
            string serverIp = (string)data["data"]["attributes"]["ip"];
            string serverPort = (string)data["data"]["attributes"]["port"];
            string serverPlayers = (string)data["data"]["attributes"]["players"];
            string serverMaxPlayers = (string)data["data"]["attributes"]["maxPlayers"];

            return serverName;
        }

    }

    public class BattleMetrics
    {
        public string name { get; set; }
        public string ip { get; set; }
        public string port { get; set; }
        public int players { get; set; }
        public int maxPlayers { get; set; }
    }

}
