public class OnlyOneColor : BalloonModel
{
    public OnlyOneColor(int red, int white, int green) : base(red, white, green) { }
    private int red = 1;
    private int white = 1;
    private int green = 1;
    public override void PushGreen()
    {
        greenBalloons--;
        green--;
        if(red != 1 || white != 1)
        {
            GameLoose();
        }
        CheckWin();
    }

    public override void PushRed()
    {
        redBalloons--;
        red--;
        if (green != 1 || white != 1)
        {
            GameLoose();
        }
        CheckWin();
    }

    public override void PushWhite()
    {
        whiteBalloons--;
        white--;
        if (red != 1 || green != 1)
        {
            GameLoose();
        }
        CheckWin();
    }

    protected override void CheckWin()
    {
        if(greenBalloons == 0 || redBalloons == 0 || whiteBalloons == 0)
        {
            GameWin();
        }
    }
}
