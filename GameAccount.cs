using System;
using System.Collections.Generic;

public class GameAccount
{
    public BasePlayer Player { get; private set; }
    private List<Game> gamesHistory;

    public GameAccount(BasePlayer player)
    {
        Player = player;
        gamesHistory = new List<Game>();
    }

    public void WinGame(BasePlayer opponent, BaseGame game)
    {
        int ratingChange = opponent.WinGame(game, Player.UserName);
        Player.CurrentRating += ratingChange;
        Player.GamesCount++;
        gamesHistory.Add(new Game(opponent.UserName, true, ratingChange, Player.GamesCount));
    }

    public void LoseGame(BasePlayer opponent, BaseGame game)
    {
        int ratingChange = Player.LoseGame(game);
        Player.CurrentRating = Math.Max(1, Player.CurrentRating - ratingChange);
        Player.GamesCount++;
        gamesHistory.Add(new Game(opponent.UserName, false, ratingChange, Player.GamesCount));
    }

    public void GetStats()
    {
        Console.WriteLine($"Game history for {Player.UserName}:");
        Console.WriteLine("Opponent\tOutcome\tRating\tGame Index");

        foreach (var game in gamesHistory)
        {
            Console.WriteLine($"{game.OpponentName}\t\t{(game.IsWinner ? "Win" : "Loss")}\t\t{game.Rating}\t\t{game.GameIndex}");
        }
    }
}
