using DSharpPlus;
using DSharpPlus.EventArgs;

namespace Kaffebot_Discord
{
    internal class Program
    {
        static Kaffekoe kaffe = new Kaffekoe();
        static async Task Main(string[] args)
        {
            var discordClient = new DiscordClient(new DiscordConfiguration
            {
                Token = "",
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All
            });

            discordClient.MessageCreated += BotMessageCreated;
            
            await discordClient.ConnectAsync();
            await Task.Delay(-1);
            
            


        }

        private static async Task BotMessageCreated(DiscordClient client, MessageCreateEventArgs msg)
        {
            // Add a person to Queue

            if (string.Equals(msg.Message.Content, "!add", StringComparison.OrdinalIgnoreCase))
            {
                string name = msg.Author.Username;
                Person person = new Person(name);
                kaffe.Enqueue(person);
                await msg.Message.RespondAsync($"{name} has been added to the Queue");


            }
            // Check the current que

            if (string.Equals(msg.Message.Content, "!check", StringComparison.OrdinalIgnoreCase))
            {
                await msg.Message.RespondAsync(kaffe.ToString());
            }

            // Rotate the queueu

            if (string.Equals(msg.Message.Content, "!rotate", StringComparison.OrdinalIgnoreCase))
            {
                kaffe.Rotate();
                await msg.Message.RespondAsync(kaffe.ToString());
            }

            //if (string.Equals(msg.Message.Content, "robert", StringComparison.OrdinalIgnoreCase))
            //{
            //    await msg.Message.RespondAsync("Den där Robert är inget att ha");
            //}

            //if (msg.Message.Content.Contains("Red bull", StringComparison.OrdinalIgnoreCase))
            //{
            //    await msg.Message.RespondAsync("Red Bull Ger dig Vingar!!!");
            //}


        }

        

      
    }
}