using UnityEngine;

public class BalloonController : MonoBehaviour
{
    [SerializeField] GameObject buttonAll, buttonOnlyOne;
    [SerializeField] BalloonView balloonView;
    [SerializeField] int maxBalloonsOneColor = 10;

    public void StartGameAllDestruction()
    {        
        var model = new PushEmAll(GetRandomNumber(), GetRandomNumber(), GetRandomNumber());
        CreateBalloons(model);
    }

    public void StartGameOnlyOneColor()
    {
        var model = new OnlyOneColor(GetRandomNumber(), GetRandomNumber(), GetRandomNumber());
        CreateBalloons(model);
    }

    private void CreateBalloons(BalloonModel balloonModel)
    {
        var presenter = new BalloonPresenter(balloonModel, balloonView);
        presenter.Init();
        HideButtons();
    }

    private int GetRandomNumber()
    {
        System.Random random = new System.Random();
        if (maxBalloonsOneColor <= 1)
        {
            maxBalloonsOneColor = random.Next(2, 10);
        }
        
        int number = random.Next(1, maxBalloonsOneColor);
        return number;
    }
    private void HideButtons()
    {
        buttonAll.SetActive(false);
        buttonOnlyOne.SetActive(false);
    }
}
