using UnityEngine;
/*
 * ����� � ������� ��� ���������. � � �� ���� ������ ������. ��� ��� ����������� � ���� _moveStrategy � _coordinatesHome ��� �������
 * ���� ���� ����������������� �����, ��� � ���������� �����, ����� ��� ��������, �� ��� �� ��������. ��� �� ������ ������, ����� ����� ��������.
 * ��� ���� ��� ����� ��� ��������� � �������, � ������ � � �����, ��� ��� ���� � ������� ������� ����� ����� new MoveToAnywhere ��� 
 * ��������� �������� � _pointsOfInterest.WorkCoordinates, �� ������ �� ���������� � � ������� ������ ������ �������� ���. 
 * ���� ��� ��� ������� � ������������, �� ��������. � ������� � ������� ������, ������ �� ������ ������� �������, �� �� ������� new MoveToAnywhere ��� 
 * ������ ������ ������� � ������� _pointsOfInterest.WorkCoordinates
 * �� ������ ���������� �� ����� � ���. ������� ������ �� �������� � ��� � �� ���� �����.
 * 
 */
public class PresenterBusinessCube : IPresenter
{
    private BusinessCube _businessCube;
    private IViewCubeMovement _viewCubeMovement;
    private PointsOfInterestForBusinessCube _pointsOfInterest;
    //����� �������
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
        Debug.Log($"�������� � ������");
        Debug.Log($"������� ���������� {_pointsOfInterest.WorkCoordinates}");

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
        Debug.Log($"�������� � �����");
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

        Debug.Log($"�������� ���");
        BusinessCube.NamesOfPoint point = _businessCube.GetNameOfPoint();
        
        if (point == BusinessCube.NamesOfPoint.None)
        {
            Debug.Log($"�������� �� �����");
            _viewCubeMovement.SetNewStrategy(_stayStrategy);
        }
        else if (point == BusinessCube.NamesOfPoint.Home)
        {
            Debug.Log($"��������� �����");
            _viewCubeMovement.SetNewStrategy(new MoveToAnywhere(_pointsOfInterest.HomeCoordinates, _viewCubeMovement.Transform, _businessCube.Speed));
        }
        else if (point == BusinessCube.NamesOfPoint.Work)
        {
            Debug.Log($"��������� �� ������");
            _viewCubeMovement.SetNewStrategy(new MoveToAnywhere(_pointsOfInterest.WorkCoordinates, _viewCubeMovement.Transform, _businessCube.Speed));
        }
        
        Debug.Log($"�������� ���");

    }
     * */
}
