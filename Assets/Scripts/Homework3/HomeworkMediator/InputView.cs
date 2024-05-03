using UnityEngine;

public class InputView : MonoBehaviour
{
    private IMediatorInput _mediator;
    private bool isPlayerLive;

    void Update()
    {
        if (isPlayerLive)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _mediator.DecreaseHp();


            if (Input.GetKeyDown(KeyCode.N))
                _mediator.LvlUp();
        }

    }

    public void SetMediator(IMediatorInput mediator)
    {
        _mediator = mediator;
    }

    public void StartPlaying() => isPlayerLive = true;
    

    public void StopPlaying() => isPlayerLive = false;
    
}
