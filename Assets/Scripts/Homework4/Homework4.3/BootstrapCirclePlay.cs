using UnityEngine;
using Zenject;

public class BootstrapCirclePlay : MonoBehaviour
{
    [SerializeField] private int minCircles, maxCircles; 
    private CircleMediator _mediator;

    void Start()
    {
        _mediator.StartGame(minCircles, maxCircles);
    }

    [Inject]
    private void Construct(CircleMediator mediator)
    {
        _mediator = mediator;
    }
}
