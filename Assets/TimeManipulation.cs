using UnityEngine;

public class TimeManipulation : MonoBehaviour
{
    [SerializeField] private float _timeScale;

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

}
