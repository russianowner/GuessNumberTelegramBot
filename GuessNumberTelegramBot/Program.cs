using GuessNumberTelegramBot.Handlers;
using GuessNumberTelegramBot.Services;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();
var token = config["BotToken"];
if (string.IsNullOrEmpty(token))
{
    return;
}
var bot = new TelegramBotClient(token);
var gameService = new GameService();
var handler = new UpdateHandler(bot, gameService);
var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = Array.Empty<UpdateType>() 
};
using var cts = new CancellationTokenSource();
bot.StartReceiving(
    (client, update, token) => handler.HandleUpdateAsync(update),
    (client, exception, token) =>
    {
        Console.WriteLine($"⚠️ Error: {exception.Message}");
        return Task.CompletedTask;
    }, 
    receiverOptions,
    cts.Token
);
var me = await bot.GetMe();
Console.WriteLine($"@{me.Username} работает");
Console.ReadKey();
cts.Cancel();
