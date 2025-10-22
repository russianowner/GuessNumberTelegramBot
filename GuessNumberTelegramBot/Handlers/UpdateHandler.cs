using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using GuessNumberTelegramBot.Services;

namespace GuessNumberTelegramBot.Handlers;

public class UpdateHandler
{
    private readonly ITelegramBotClient _bot;
    private readonly GameService _gameService;

    public UpdateHandler(ITelegramBotClient bot, GameService gameService)
    {
        _bot = bot;
        _gameService = gameService;
    }
    public async Task HandleUpdateAsync(Update update)
    {
        if (update.Type != UpdateType.Message || update.Message?.Text == null)
            return;
        var chatId = update.Message.Chat.Id;
        var text = update.Message.Text.Trim();
        var username = update.Message.From?.FirstName ?? "Кто-то";
        string? reply = null;
        if (text.Equals("/start", StringComparison.OrdinalIgnoreCase))
        {
            reply = _gameService.StartGame(chatId);
        }
        else if (text.Equals("/stop", StringComparison.OrdinalIgnoreCase))
        {
            reply = _gameService.StopGame(chatId);
        }
        else
        {
            reply = _gameService.ProcessGuess(chatId, username, text);
        }
        if (!string.IsNullOrEmpty(reply))
            await _bot.SendMessage(chatId, reply);
    }
}
