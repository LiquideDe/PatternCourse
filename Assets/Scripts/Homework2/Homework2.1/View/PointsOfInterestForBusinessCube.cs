using UnityEngine;

/*
 * ѕонимаю, что модель должна раздельно быть раздельно от представлени€, но как хранить точки лучше не решил.
 * ѕлюс показалось хорошей идеей хранить все в одном месте, непосредственно места и список их имен. * 
 */
public class PointsOfInterestForBusinessCube : MonoBehaviour
{
    //¬опрос по этой конструкции, где то видел, что нельз€ через зап€тую объ€вл€ть пол€, где то видел, что можно.  ак можно?
    [SerializeField] Transform homePoint, workPoint;
    public enum NamesOfPoint { None, Home, Work }

    public Vector3 HomeCoordinates { get => homePoint.position; }
    public Vector3 WorkCoordinates { get => workPoint.position; }
}
