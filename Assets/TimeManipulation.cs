using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManipulation : MonoBehaviour
{
    public float TimeScale;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeScale = Time.timeScale;
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Time.timeScale = 0.0f;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            Time.timeScale = 1f;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            Time.timeScale = 10f;
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            Time.timeScale = 15f;
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            Time.timeScale = 30f;
        else if (Input.GetKeyDown(KeyCode.Alpha6))
            Time.timeScale = 60f;
    }
}
