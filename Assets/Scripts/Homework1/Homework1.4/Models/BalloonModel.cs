using System;

public abstract class BalloonModel : IBalloon
{
    public event Action Win;
    public event Action Loose;
    protected int redBalloons;
    protected int whiteBalloons;
    protected int greenBalloons;
    
    public BalloonModel(int red, int white, int green)
    {
        redBalloons = red;
        whiteBalloons = white;
        greenBalloons = green;
    }
    public int RedBalloons { get => redBalloons; }
    public int WhiteBalloons { get => whiteBalloons; }
    public int GreenBalloons { get => greenBalloons; }
    public abstract void PushRed();
    public abstract void PushWhite();
    public abstract void PushGreen();
    protected abstract void CheckWin();
    protected void GameWin()
    {
        Win?.Invoke();
    }
    protected void GameLoose()
    {
        Loose?.Invoke();
    }

}
