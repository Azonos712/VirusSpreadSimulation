using UnityEditor;
using UnityEngine;

//[ExecuteInEditMode]
public class AutomaticLightPower : MonoBehaviour
{
    private Light _light;
    private DayNightCycle _dayNightCycle;
    private float _timer;
    void Start()
    {
        _light = GetComponent<Light>();
        _dayNightCycle = FindObjectOfType<DayNightCycle>();
    }

    void Update()
    {
        //��� ������� �� ������ ������� ������ ����� �����������
        if (_timer <= 0)
        {
            _light.intensity = 1 - _dayNightCycle.Sun.intensity;
            _timer = 1;
        }

        _timer -= Time.deltaTime;
    }
}
