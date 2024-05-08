public class DestroyAllCircles : VictoryCondition
{
    protected override void CheckCondition()
    {
        int summ = 0;
        foreach(int amount in _amountCirclesByType)
        {
            summ += amount;
        }

        if (summ == 0)
            Win();
    }
}
