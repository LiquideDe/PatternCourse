using UnityEngine;

public class CircleMonobehavior : MonoBehaviour
{
    [SerializeField]TypeCircle _typeCircle;

    public TypeCircle TypeCircle => _typeCircle;

    public void Initialize(CircleConfig circleConfig)
    {
        _typeCircle = circleConfig.TypeCircle;
    }

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);
}
