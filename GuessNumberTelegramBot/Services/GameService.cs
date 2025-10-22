using GuessNumberTelegramBot.Models;
using System.Collections.Concurrent;

namespace GuessNumberTelegramBot.Services;

public class GameService
{
    private readonly ConcurrentDictionary<long, GameSession> _sessions = new();

    public string StartGame(long chatId)
    {
        if (_sessions.ContainsKey(chatId))
            return "Игра уже идёт! 🎯 Попробуйте угадать число";
        var session = new GameSession
        {
            SecretNumber = Random.Shared.Next(1, 101),
            Attempts = 0,
            Active = true
        };
        _sessions[chatId] = session;
        return "🎯 Игра началась! Я загадал число от 1 до 100. Попробуйте угадать!";
    }
    public string StopGame(long chatId)
    {
        if (!_sessions.TryRemove(chatId, out var session))
            return "🙃 Нет активной игры";
        session.Active = false;
        return $"🛑 Игра остановлена. Загаданное число было {session.SecretNumber}.";
    }
    public string ProcessGuess(long chatId, string username, string message)
    {
        if (!_sessions.TryGetValue(chatId, out var session) || !session.Active)
            return string.Empty; 
        if (!int.TryParse(message, out int guess))
            return $"{username}, введите число!";
        session.Attempts++;
        if (guess == session.SecretNumber)
        {
            _sessions.TryRemove(chatId, out _);
            return $"🎉 {username} угадал число {guess} за {session.Attempts} попыток!\nЧтобы начать новую игру — /start";
        }
        return guess < session.SecretNumber
            ? $"🔼 {username}, моё число больше!"
            : $"🔽 {username}, моё число меньше!";
    }
}
