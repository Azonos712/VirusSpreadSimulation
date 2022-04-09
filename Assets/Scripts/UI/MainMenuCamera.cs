using UnityEngine;
using UnityEngine.UI;

public class MainMenuCamera : MonoBehaviour
{
    [SerializeField] private Transform[] WayPoints;
    private Transform _currentTarget;
    private int _pointIndex;
    public float MovementSpeed;
    public float RotationSpeed;

    private void Start()
    {
        _pointIndex = Random.Range(0, WayPoints.Length);
        _currentTarget = WayPoints[_pointIndex].transform;
        transform.position = _currentTarget.position;
    }

    private void Update()
    {
        MoveAndRotateToTarget();

        if (Vector3.Distance(transform.position, _currentTarget.position) <= 3)
            SetNextTarget();
    }

    private void MoveAndRotateToTarget()
    {
        //��������� ����������� �������� � ������� ����
        Vector3 dir = _currentTarget.position - transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * RotationSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        //�������� ������ ����������� � ����������������, ����� �� ���� ������ ���������
        //����� ����������� ���� ������ �� �������� � �������� ������� ����� �������
        //� ���������� � ������� ����������� ��� ������ ���������� ������
        transform.Translate(dir.normalized * MovementSpeed * Time.deltaTime, Space.World);
    }

    private void SetNextTarget()
    {
        _pointIndex = ++_pointIndex % WayPoints.Length;
        _currentTarget = WayPoints[_pointIndex];
    }
}