using UnityEngine;

public class AutomaticLightPower : MonoBehaviour
{
    private Light _light;
    private DayNightCycle _dayNightCycle;
    private float _timer;

    void Start()
    {
        _dayNightCycle = FindObjectOfType<DayNightCycle>();
        _light = GetComponent<Light>();
    }

    void Update()
    {
        //Увеличил время обновления, фризы исчезли
        if (_timer <= 0)
        {
            _light.intensity = 1 - _dayNightCycle.Sun.intensity;
            _timer = Random.Range(5,31);
        }

        _timer -= Time.deltaTime;
    }
}