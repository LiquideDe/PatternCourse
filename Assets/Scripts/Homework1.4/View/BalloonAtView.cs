using UnityEngine;

public class BalloonAtView : MonoBehaviour
{
    [SerializeField] string nameBalloon;
    public string Name { get => nameBalloon; }

    public void DestroyIt()
    {
        Destroy(gameObject);
    }
}
