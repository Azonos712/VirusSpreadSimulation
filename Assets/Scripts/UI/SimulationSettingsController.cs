using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimulationSettingsController : MonoBehaviour
{
    [SerializeField] private Slider _infectedSlider;
    [SerializeField] private TMP_Text _infectedText;

    public void SetInfected(float value)
    {
        _infectedText.text = Math.Truncate(value).ToString();// value.ToString("0");
    }
    public int GetInfected()
    {
        return (int)Math.Truncate(_infectedSlider.value);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
