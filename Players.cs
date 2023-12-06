using System;

public abstract class BasePlayer
{
    public string UserName { get; protected set; }
    public int CurrentRating { get; set; } // Зроблено set публічним
    public int GamesCount { get; set; }    // Зроблено set публічним

    public BasePlayer(string userName, int initialRating)
    {
        UserName = userName;
        CurrentRating = initialRating;
        GamesCount = 0;
    }

    public abstract int WinGame(BaseGame game, string opponentName);
    public abstract int LoseGame(BaseGame game);
    public abstract void GetStats();
}


public class StandardPlayer : BasePlayer
{
    public StandardPlayer(string userName, int initialRating) : base(userName, initialRating)
    {
    }

    public override int WinGame(BaseGame game, string opponentName)
    {
        int points = game.CalculateRatingChange();
        Console.WriteLine($"{UserName} wins against {opponentName}. Rating: +{points}. Total Games: {GamesCount + 1}");
        return points;
    }

    public override int LoseGame(BaseGame game)
    {
        int points = game.CalculateRatingChange();
        Console.WriteLine($"{UserName} loses. Rating: -{points}. Total Games: {GamesCount + 1}");
        return points;
    }

    public override void GetStats()
    {
        Console.WriteLine($"Stats for {UserName}: Rating: {CurrentRating}, Games Played: {GamesCount}");
    }
}

public class ReducedPenaltyPlayer : BasePlayer
{
    public ReducedPenaltyPlayer(string userName, int initialRating) : base(userName, initialRating)
    {
    }

    public override int WinGame(BaseGame game, string opponentName)
    {
        int points = game.CalculateRatingChange() / 2;
        Console.WriteLine($"{UserName} wins against {opponentName}. Rating: +{points}. Total Games: {GamesCount + 1}");
        return points;
    }

    public override int LoseGame(BaseGame game)
    {
        int points = game.CalculateRatingChange() / 2;
        Console.WriteLine($"{UserName} loses. Rating: -{points}. Total Games: {GamesCount + 1}");
        return points;
    }

    public override void GetStats()
    {
        Console.WriteLine($"Stats for {UserName}: Rating: {CurrentRating}, Games Played: {GamesCount}");
    }
}

public class WinningStreakPlayer : BasePlayer
{
    private int consecutiveWins;

    public WinningStreakPlayer(string userName, int initialRating) : base(userName, initialRating)
    {
        consecutiveWins = 0;
    }

    public override int WinGame(BaseGame game, string opponentName)
    {
        int points = game.CalculateRatingChange();
        consecutiveWins++;
        if (consecutiveWins >= 3)
        {
            points += 10;
        }
        Console.WriteLine($"{UserName} wins against {opponentName}. Rating: +{points}. Total Games: {GamesCount + 1}");
        return points;
    }

    public override int LoseGame(BaseGame game)
    {
        int points = game.CalculateRatingChange();
        consecutiveWins = 0;
        Console.WriteLine($"{UserName} loses. Rating: -{points}. Total Games: {GamesCount + 1}");
        return points;
    }

    public override void GetStats()
    {
        Console.WriteLine($"Stats for {UserName}: Rating: {CurrentRating}, Games Played: {GamesCount}");
    }
}
