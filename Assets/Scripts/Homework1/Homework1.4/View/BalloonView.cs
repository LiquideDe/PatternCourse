using UnityEngine;
using TMPro;

public class BalloonView : MonoBehaviour, IBallonView
{
    IBallonView.CheckCollider checkCollider;
    [SerializeField] GameObject redBalloon, greenBalloon, whiteBalloon;
    [SerializeField] TextMeshProUGUI textWin, textLoose;
    [SerializeField] int limitX = 30;
    [SerializeField] int limitZ = 15;
    private bool isStarted;

    private void Update()
    {
        if (isStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit))
                {
                    checkCollider?.Invoke(hit.collider);
                }
            }
        }
    }
    public void GenerateBallons(int red, int green, int white)
    {
        System.Random random = new System.Random();
        for(int i = 0; i < red; i++)
        {
            Transform balloon = Instantiate(redBalloon).transform;
            balloon.position = new Vector3(random.Next(1, limitX),0,random.Next(1, limitZ));
        }
        for (int i = 0; i < green; i++)
        {
            Transform balloon = Instantiate(greenBalloon).transform;
            balloon.position = new Vector3(random.Next(1, limitX), 0, random.Next(1, limitZ));
        }
        for (int i = 0; i < white; i++)
        {
            Transform balloon = Instantiate(whiteBalloon).transform;
            balloon.position = new Vector3(random.Next(1, limitX), 0, random.Next(1, limitZ));
        }
        isStarted = true;
    }

    public void RegDelegate(IBallonView.CheckCollider checkCollider)
    {
        this.checkCollider = checkCollider;
    }

    public void ShowGameLoose()
    {
        isStarted = false;
        textLoose.gameObject.SetActive(true);
    }

    public void ShowGameWin()
    {
        isStarted = false;
        textWin.gameObject.SetActive(true);
    }
}
