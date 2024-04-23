using UnityEngine;

/*
 * ����� ����� ������������ � �������� ������� � MVP. ����� ������ ���������� MVP �� ���� ������ Unity, 
 * ������ � Presentation ���������� �� ���� ��� View, ���� ��� UI, ������ ��� 3D �����������.
 * � ���� ������� ��� UI ������� �������� ���� View, �� ����������� ��������������� �� ������������ �������, 
 * ������� �� ���� ��� ������������ ��� ������������ View. ����� ��� ������������ ��� ��������, ��� ��������� ������ ������������ 
 * ������� ���������, � ��� ��� ������������ �� ����� ������������ ��� ������� ���������.
 * 
 * BusinessCube ������ ��������, ��� ���� ������� ������� Businessman, �� � ���� �� ����� ������� ���, ������� BusinessCube.
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
