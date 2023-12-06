public abstract class BaseGame
{
    public abstract int CalculateRatingChange();
}

public class StandardGame : BaseGame
{
    public override int CalculateRatingChange()
    {
        // Implement standard rating change logic
        return 20;
    }
}

public class TrainingGame : BaseGame
{
    public override int CalculateRatingChange()
    {
        // Training games have no rating change
        return 0;
    }
}

public class SinglePlayerGame : BaseGame
{
    public override int CalculateRatingChange()
    {
        // Single player games have different rating change logic
        return 15;
    }
}
