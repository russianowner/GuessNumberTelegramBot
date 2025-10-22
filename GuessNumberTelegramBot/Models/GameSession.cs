namespace GuessNumberTelegramBot.Models;

public class GameSession
{
    public int SecretNumber { get; set; }
    public int Attempts { get; set; }
    public bool Active { get; set; } = true;
}
