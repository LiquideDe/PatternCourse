using UnityEngine;

public class TriggerPlaceForBusinessCube : MonoBehaviour
{
    private bool isCome;
    private void OnTriggerEnter(Collider other)
    {
        if(isCome == false)
        {
            if (other.TryGetComponent<ViewCubeMovement>(out ViewCubeMovement viewCube))
            {
                isCome = true;
                viewCube.ReachPoint();                
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        isCome = false;
    }
}
