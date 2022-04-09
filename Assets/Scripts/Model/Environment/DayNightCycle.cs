using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class DayNightCycle : MonoBehaviour
{
    [Range(0f, 1f)]
    public float CurrentTime;
    public float FullDayLength;
    public float StartTime;

    private float _timeHavePassed;
    [SerializeField] private float _dayHavePassed;
    public float DaysHavePassed => _dayHavePassed;

    [SerializeField] private float _timeRate;
    public Vector3 Noon;//полдень

    [Header("Sun")]
    public Light Sun;
    public Gradient SunColor;
    public AnimationCurve SunIntensity;

    [Header("Moon")]
    public Light Moon;
    public Gradient MoonColor;
    public AnimationCurve MoonIntensity;

    [Header("Other Lighting")]
    public AnimationCurve LightingIntensityMultiplier;
    public AnimationCurve ReflectionIntensityMultiplier;

    void Awake()
    {
        _timeRate = 1.0f / FullDayLength;
        CurrentTime = StartTime;
        Sun.intensity = SunIntensity.Evaluate(CurrentTime);
        Moon.intensity = MoonIntensity.Evaluate(CurrentTime);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += _timeRate * Time.deltaTime;
        _timeHavePassed += Time.deltaTime;
        _dayHavePassed = _timeHavePassed / FullDayLength;

        if (CurrentTime >= 1.0f)
            CurrentTime = 0.0f;

        //light rotation
        //Sun.transform.RotateAround(Vector3.zero, Vector3.right, (CurrentTime - 0.25f) );
        Sun.transform.localEulerAngles = (CurrentTime - 0.25f) * Noon * 4.0f;//leulerAngles
        Moon.transform.localEulerAngles = (CurrentTime - 0.75f) * Noon * 4.0f;

        //light intensity
        Sun.intensity = SunIntensity.Evaluate(CurrentTime);
        Moon.intensity = MoonIntensity.Evaluate(CurrentTime);

        //change colors
        Sun.color = SunColor.Evaluate(CurrentTime);
        Moon.color = MoonColor.Evaluate(CurrentTime);

        //enable/disable the sun
        SwitchLightSource(Sun, 0.0f);
        //SwitchLightSource(Sun);

        //enable/disable the moon
        SwitchLightSource(Moon, 0.0f);
        //SwitchLightSource(Moon);

        //lighting and reflections intensity
        RenderSettings.ambientIntensity = LightingIntensityMultiplier.Evaluate(CurrentTime);
        RenderSettings.reflectionIntensity = ReflectionIntensityMultiplier.Evaluate(CurrentTime);
    }

    private void SwitchLightSource(Light light, float limit)
    {
        if (light.intensity <= limit && light.gameObject.activeInHierarchy)
            light.gameObject.SetActive(false);
        else if (light.intensity > limit && !light.gameObject.activeInHierarchy)
            light.gameObject.SetActive(true);
    }
    private void SwitchLightSource(Light light)
    {
        var rotation = light.gameObject.transform.localEulerAngles.x;//rotation.x;
        if (rotation >= -10 && rotation <= 190)
            light.gameObject.SetActive(true);
        else
            light.gameObject.SetActive(false);
    }
}
