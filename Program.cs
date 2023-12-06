class Program
{
    static void Main()
    {
        BasePlayer player1 = new StandardPlayer("Player1", 1000);
        BasePlayer player2 = new ReducedPenaltyPlayer("Player2", 1200);
        BasePlayer player3 = new WinningStreakPlayer("Player3", 1100);

        GameFactory gameFactory = new GameFactory();

        BaseGame standardGame = gameFactory.CreateGame("Standard");
        BaseGame trainingGame = gameFactory.CreateGame("Training");
        BaseGame singlePlayerGame = gameFactory.CreateGame("SinglePlayer");

        GameAccount gameAccount1 = new GameAccount(player1);
        GameAccount gameAccount2 = new GameAccount(player2);
        GameAccount gameAccount3 = new GameAccount(player3);

        gameAccount1.WinGame(player2, standardGame);
        gameAccount2.LoseGame(player1, standardGame);

        gameAccount1.WinGame(player2, trainingGame);
        gameAccount2.LoseGame(player1, trainingGame);

        gameAccount3.WinGame(player3, singlePlayerGame);
        gameAccount3.WinGame(player3, singlePlayerGame);
        gameAccount3.WinGame(player3, singlePlayerGame);

        gameAccount1.GetStats();
        gameAccount2.GetStats();
        gameAccount3.GetStats();
    }
}
