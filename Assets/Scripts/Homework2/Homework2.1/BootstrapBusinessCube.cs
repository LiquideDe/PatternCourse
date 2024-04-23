using UnityEngine;

/*
 * Решил опять поиздеваться и попыться сделать в MVP. Нашел пример реализации MVP на гите самого Unity, 
 * просто у Presentation появляется по сути два View, один для UI, второй для 3D отображения.
 * В этом задании нет UI поэтому остается один View, он отвественен непосредственно за передвижение объекта, 
 * поэтому не надо его воспринимать как классический View. Решил еще использовать два паттерна, для состояний модели используется 
 * паттерн состояний, а вот для передвижений на сцене используется уже паттерн стратегия.
 * 
 * BusinessCube просто название, как есть деловой человек Businessman, но у меня на сцене деловой куб, поэтому BusinessCube.
*/


public class BootstrapBusinessCube : MonoBehaviour
{
    [SerializeField] ViewCubeMovement _viewCubeMovement;
    [SerializeField] PointsOfInterestForBusinessCube _pointsOfInterest;

    void Start()
    {
        PresenterBusinessCube presenter = new PresenterBusinessCube(_viewCubeMovement, _pointsOfInterest);
    }

}
