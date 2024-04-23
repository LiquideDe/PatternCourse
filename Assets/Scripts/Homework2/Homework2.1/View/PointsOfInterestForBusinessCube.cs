using UnityEngine;

/*
 * �������, ��� ������ ������ ��������� ���� ��������� �� �������������, �� ��� ������� ����� ����� �� �����.
 * ���� ���������� ������� ����� ������� ��� � ����� �����, ��������������� ����� � ������ �� ����. * 
 */
public class PointsOfInterestForBusinessCube : MonoBehaviour
{
    //������ �� ���� �����������, ��� �� �����, ��� ������ ����� ������� ��������� ����, ��� �� �����, ��� �����. ��� �����?
    [SerializeField] Transform homePoint, workPoint;
    public enum NamesOfPoint { None, Home, Work }

    public Vector3 HomeCoordinates { get => homePoint.position; }
    public Vector3 WorkCoordinates { get => workPoint.position; }
}
