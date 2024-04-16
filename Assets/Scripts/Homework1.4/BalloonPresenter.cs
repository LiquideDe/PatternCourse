using UnityEngine;

public class BalloonPresenter
{
    private IBalloon balloonModel;
    private IBallonView ballonView;

    public BalloonPresenter(IBalloon balloonModel, IBallonView ballonView)
    {
        this.balloonModel = balloonModel;
        this.ballonView = ballonView;
    }

    public void Init()
    {
        balloonModel.Win += GameWin;
        balloonModel.Loose += GameLoose;
        ballonView.RegDelegate(CheckCollider);
        
        ballonView.GenerateBallons(balloonModel.RedBalloons, balloonModel.GreenBalloons, balloonModel.WhiteBalloons);
    }

    private void CheckCollider(Collider collider)
    {
        if(collider.TryGetComponent(out BalloonAtView balloon))
        {
            if(string.Compare(balloon.Name, "Red", true) == 0)
            {
                balloonModel.PushRed();
            }
            else if (string.Compare(balloon.Name, "Green", true) == 0)
            {
                balloonModel.PushGreen();
            }
            else if (string.Compare(balloon.Name, "White", true) == 0)
            {
                balloonModel.PushWhite();
            }
            balloon.DestroyIt();
        }
    }

    private void GameLoose()
    {
        ballonView.ShowGameLoose();
    }

    private void GameWin()
    {
        ballonView.ShowGameWin();
    }
}
