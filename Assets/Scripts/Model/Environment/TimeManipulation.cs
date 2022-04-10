using UnityEngine;

public class TimeManipulation : MonoBehaviour
{
    [SerializeField] private float _timeScale;
    private float _lastTimeScale;

    public void SetTimeScaleByKeyCode(KeyCode key)
    {
        Time.timeScale = key switch
        {
            KeyCode.Alpha1 => 0f,
            KeyCode.Alpha2 => 1f,
            KeyCode.Alpha3 => 30f,
            KeyCode.Alpha4 => 60f,
            _ => Time.timeScale,
        };

        _timeScale = Time.timeScale;
    }

    public void StopTime()
    {
        _lastTimeScale = Time.timeScale;
        Time.timeScale = 0f;
    }

    public void ResumeTime()
    {
        Time.timeScale = _lastTimeScale;
    }
}