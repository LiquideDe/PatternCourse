using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewPlayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textLvl, textHp;
    [SerializeField] GameObject PanelRestart;
    [SerializeField] Button buttonRestart;

    private IMediator _mediator;

    private void OnEnable()
    {
        HideRestartPanel();
        buttonRestart.onClick.AddListener(RestartLvl);
    }

    public void SetMediator(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void UpdateTextHp(int hp) => textHp.text = $"Здоровье: {hp}";

    public void UpdateTextLvl(int lvl) => textLvl.text = $"Уровень: {lvl}";

    public void ShowRestartPanel() => PanelRestart.SetActive(true);

    public void HideRestartPanel() => PanelRestart.SetActive(false);

    private void RestartLvl() => _mediator.RestartLvl();


}
