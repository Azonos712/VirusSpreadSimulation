using UnityEngine;

public class TimeManipulation : MonoBehaviour
{
    public float TimeScale;

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Time.timeScale = GetPressedSpeedButton() switch
            {
                KeyCode.Alpha1 => 0f,
                KeyCode.Alpha2 => 1f,
                KeyCode.Alpha3 => 10f,
                KeyCode.Alpha4 => 15f,
                KeyCode.Alpha5 => 30f,
                KeyCode.Alpha6 => 60f,
                KeyCode.None => Time.timeScale,
            };

            TimeScale = Time.timeScale;
        }
    }

    private KeyCode GetPressedSpeedButton()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            return KeyCode.Alpha1;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            return KeyCode.Alpha2;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            return KeyCode.Alpha3;
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            return KeyCode.Alpha4;
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            return KeyCode.Alpha5;
        else if (Input.GetKeyDown(KeyCode.Alpha6))
            return KeyCode.Alpha6;

        return KeyCode.None;
    }
}
