using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CircleUI : MonoBehaviour
{
    [SerializeField] Button _buttonRestart, _buttonExitToMainMenu;
    [SerializeField] TextMeshProUGUI _finishText;

    public event Action RestartClicked;
    public event Action ExitToMenuClicked;

    private void OnEnable()
    {
        _buttonRestart.onClick.AddListener(Restart);
        _buttonExitToMainMenu.onClick.AddListener(ExitToMainMenu);
    }

    private void OnDisable()
    {
        _buttonRestart.onClick.RemoveAllListeners();
        _buttonExitToMainMenu.onClick.RemoveAllListeners();
    }
    
    public void ShowWin()
    {
        _finishText.text = $"ÏÎÁÅÄÀ!";
        gameObject.SetActive(true);
    }

    public void ShowLoose()
    {
        _finishText.text = $"ÏÎÐÀÆÅÍÈÅ";
        gameObject.SetActive(true);
    }
    
    public void Hide() => gameObject.SetActive(false);
    
    private void Restart() => RestartClicked?.Invoke();

    private void ExitToMainMenu() => ExitToMenuClicked?.Invoke();
}
