using UnityEngine;
using System;

public class InputCircleView : MonoBehaviour
{
    public event Action<CircleMonobehavior> ClickedOnCircle;   

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
                if (hit.collider.TryGetComponent(out CircleMonobehavior circle))
                    ClickedOnCircle?.Invoke(circle);
        }
    }
}
