public class GameFactory
{
    public BaseGame CreateGame(string gameType)
    {
        switch (gameType)
        {
            case "Standard":
                return new StandardGame();
            case "Training":
                return new TrainingGame();
            case "SinglePlayer":
                return new SinglePlayerGame();
            default:
                throw new ArgumentException("Invalid game type");
        }
    }
}
