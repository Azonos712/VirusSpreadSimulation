using UnityEngine;

public class UISpeedSettings : MonoBehaviour
{
    [SerializeField] private TimeManipulation _timeManipulation;

    public void ChangeSpeed(KeyCode key)
    {
        _timeManipulation.SetTimeScaleByKeyCode(key);
    }
}
