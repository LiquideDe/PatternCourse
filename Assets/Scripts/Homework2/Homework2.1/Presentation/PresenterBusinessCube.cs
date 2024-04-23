using UnityEngine;
/*
 *  ласс в котором все сломалось. » € не могу пон€ть почему. ¬се эти конструкции в виде _moveStrategy и _coordinatesHome это костыли
 * Ќиже есть закоментированный метод, как € изначально хотел, чтобы все работало, но оно не работает. Ќет ни ошибки ничего, класс будто зависает.
 * “ам есть еще вывод два сообщени€ в консоль, в начале и в конце, так вот если € пытаюсь создать новый класс new MoveToAnywhere или 
 * обращаюсь напр€мую к _pointsOfInterest.WorkCoordinates, то ничего не происходит и в консоль выйдет только ѕроверка раз. 
 * ≈сли все это создать в конструкторе, то работает. я дебажил с помощью студии, ставил на каждой строчке останов, но на строчке new MoveToAnywhere или 
 * просто пытаюь вывести в консоль _pointsOfInterest.WorkCoordinates
 * он просто переключал на юнити и все. ѕричину почему не работает € так и не смог найти.
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
            SetParametersMoveStrategy(_businessCube.Speed, _coordinatesWork);
        }

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

        Debug.Log($"ѕроверка раз");
        BusinessCube.NamesOfPoint point = _businessCube.GetNameOfPoint();
        
        if (point == BusinessCube.NamesOfPoint.None)
        {
            Debug.Log($"ќстаемс€ на месте");
            _viewCubeMovement.SetNewStrategy(_stayStrategy);
        }
        else if (point == BusinessCube.NamesOfPoint.Home)
        {
            Debug.Log($"ƒвигаемс€ домой");
            _viewCubeMovement.SetNewStrategy(new MoveToAnywhere(_pointsOfInterest.HomeCoordinates, _viewCubeMovement.Transform, _businessCube.Speed));
        }
        else if (point == BusinessCube.NamesOfPoint.Work)
        {
            Debug.Log($"ƒвигаемс€ на работу");
            _viewCubeMovement.SetNewStrategy(new MoveToAnywhere(_pointsOfInterest.WorkCoordinates, _viewCubeMovement.Transform, _businessCube.Speed));
        }
        
        Debug.Log($"ѕроверка два");

    }
     * */
}
