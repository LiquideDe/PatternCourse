using UnityEngine;
/*
 * Класс в котором все сломалось. И я не могу понять почему. Все эти конструкции в виде _moveStrategy и _coordinatesHome это костыли
 * Ниже есть закоментированный метод, как я изначально хотел, чтобы все работало, но оно не работает. Нет ни ошибки ничего, класс будто зависает.
 * Там есть еще вывод два сообщения в консоль, в начале и в конце, так вот если я пытаюсь создать новый класс new MoveToAnywhere или 
 * обращаюсь напрямую к _pointsOfInterest.WorkCoordinates, то ничего не происходит и в консоль выйдет только Проверка раз. 
 * Если все это создать в конструкторе, то работает. Я дебажил с помощью студии, ставил на каждой строчке останов, но на строчке new MoveToAnywhere или 
 * просто пытаюь вывести в консоль _pointsOfInterest.WorkCoordinates
 * он просто переключал на юнити и все. Причину почему не работает я так и не смог найти.
 * 
 */
public class PresenterBusinessCube : IPresenter
{
    private BusinessCube _businessCube;
    private IViewCubeMovement _viewCubeMovement;
    private PointsOfInterestForBusinessCube _pointsOfInterest;
    //далее костыли
    private MoveToAnywhere _moveStrategy;
    private StayAtPosition _stayStrategy;
    private Vector3 _coordinatesWork;
    private Vector3 _coordinatesHome;

    public PresenterBusinessCube(IViewCubeMovement viewCubeMovement, PointsOfInterestForBusinessCube pointsOfInterest)
    {

        _viewCubeMovement = viewCubeMovement;
        _viewCubeMovement.SetPresenter(this);

        _businessCube = new BusinessCube();
        _businessCube.StateWasChanged += StateWasChanged;        

        _pointsOfInterest = pointsOfInterest;
        _moveStrategy = new MoveToAnywhere(_pointsOfInterest.WorkCoordinates, _viewCubeMovement.Transform, _businessCube.Speed);
        _stayStrategy = new StayAtPosition(Vector3.zero, _viewCubeMovement.Transform, 0f);
        _coordinatesWork = _pointsOfInterest.WorkCoordinates;
        _coordinatesHome = _pointsOfInterest.HomeCoordinates;
    }

    public void ReachPoint()
    {
        _businessCube.ReachPoint();
    }

    public void StateWasChanged()
    {
        Debug.Log($"Проверка в начале");
        Debug.Log($"Выведем координаты {_pointsOfInterest.WorkCoordinates}");

        PointsOfInterestForBusinessCube.NamesOfPoint pointNameAtState = _businessCube.GetNameOfPoint();
        
        if (pointNameAtState == PointsOfInterestForBusinessCube.NamesOfPoint.None)
        {
            _viewCubeMovement.SetNewStrategy(_stayStrategy);
        }
        else if (pointNameAtState == PointsOfInterestForBusinessCube.NamesOfPoint.Home)
        {
            SetParametersMoveStrategy(_businessCube.Speed, _coordinatesHome);
        }
        else if (pointNameAtState == PointsOfInterestForBusinessCube.NamesOfPoint.Work)
        {
            //_viewCubeMovement.SetNewStrategy(new MoveToAnywhere(_coordinatesWork, _viewCubeMovement.Transform, _businessCube.Speed));
            SetParametersMoveStrategy(_businessCube.Speed, _coordinatesWork);
        }
        Debug.Log($"Проверка в конце");
    }

    private void SetParametersMoveStrategy(float speed, Vector3 coordinateDestination)
    {
        _moveStrategy.ChangeSpeed(speed);
        _moveStrategy.ChangeDestination(coordinateDestination);
        _viewCubeMovement.SetNewStrategy(_moveStrategy);
    }

    /*
     public void StateWasChanged()
    {

        Debug.Log($"Проверка раз");
        BusinessCube.NamesOfPoint point = _businessCube.GetNameOfPoint();
        
        if (point == BusinessCube.NamesOfPoint.None)
        {
            Debug.Log($"Остаемся на месте");
            _viewCubeMovement.SetNewStrategy(_stayStrategy);
        }
        else if (point == BusinessCube.NamesOfPoint.Home)
        {
            Debug.Log($"Двигаемся домой");
            _viewCubeMovement.SetNewStrategy(new MoveToAnywhere(_pointsOfInterest.HomeCoordinates, _viewCubeMovement.Transform, _businessCube.Speed));
        }
        else if (point == BusinessCube.NamesOfPoint.Work)
        {
            Debug.Log($"Двигаемся на работу");
            _viewCubeMovement.SetNewStrategy(new MoveToAnywhere(_pointsOfInterest.WorkCoordinates, _viewCubeMovement.Transform, _businessCube.Speed));
        }
        
        Debug.Log($"Проверка два");

    }
     * */
}
