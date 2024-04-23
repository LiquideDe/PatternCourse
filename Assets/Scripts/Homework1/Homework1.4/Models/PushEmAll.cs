public class PushEmAll : BalloonModel
{
    public PushEmAll(int red, int white, int green) : base(red, white, green) { }

    public override void PushGreen()
    {
        greenBalloons--;
        CheckWin();
    }

    public override void PushRed()
    {
        redBalloons--;
        CheckWin();
    }

    public override void PushWhite()
    {
        whiteBalloons--;
        CheckWin();
    }

    protected override void CheckWin()
    {
        if(greenBalloons + redBalloons + whiteBalloons == 0)
        {
            GameWin();
        }
    }
}
