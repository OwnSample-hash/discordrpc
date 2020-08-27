using DiscordRPC;
using DiscordRPC.Logging;
using DiscordRPC.Message;
using System;
using System.Timers;

namespace discord_rpc
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			DiscordRpcClient client = new DiscordRpcClient("748602078821351516");
			client.Logger = new ConsoleLogger
			{
				Level = LogLevel.Warning
			};
			client.OnReady += delegate(object sender, ReadyMessage e)
			{
				Console.WriteLine("Received Ready from user {0}", e.User.Username);
			};
			client.OnPresenceUpdate += delegate(object sender, PresenceMessage e)
			{
				Console.WriteLine("Received Update! {0}", e.Presence);
			};
			Console.WriteLine("Initing");
			client.Initialize();
			Console.WriteLine("Done");
			client.SetPresence(new RichPresence
			{
				Details = "Lazarth.exe",
				State = "Lazarth.exe",
				Assets = new Assets
				{
					LargeImageKey = "lazarth",
					LargeImageText = "Lazarth.exe",
					SmallImageKey = "lazarth"
				}
			});
			Timer timer = new Timer(150.0);
			timer.Elapsed += delegate
			{
				client.Invoke();
			};
			timer.Start();
		}
	}
}
