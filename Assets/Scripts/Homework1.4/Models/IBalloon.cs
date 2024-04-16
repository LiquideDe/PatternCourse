using System;

public interface IBalloon
{
    public event Action Win;
    public event Action Loose;
    public int RedBalloons { get; }
    public int WhiteBalloons { get; }
    public int GreenBalloons { get; }
    public void PushRed();
    public void PushWhite();
    public void PushGreen();
}
