using UnityEngine;

public class BootstrapMediator : MonoBehaviour
{
    [SerializeField] private InputView _inputView;
    [SerializeField] private ViewPlayer _viewPlayer;
    [SerializeField] private int _startHp;
    [SerializeField] private int _startLvl;

    void Start()
    {
        PlayerModel player = new PlayerModel(_startHp, _startLvl);
        new Mediator(_inputView, _viewPlayer, player);        
    }    
}
