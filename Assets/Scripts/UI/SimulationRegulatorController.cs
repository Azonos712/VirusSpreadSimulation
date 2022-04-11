using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimulationRegulatorController : MonoBehaviour
{
    [SerializeField] private TMP_Text _chanceToInfecteText;
    [SerializeField] private Slider _chanceToInfecteSlider;

    private void Awake()
    {
        _chanceToInfecteSlider.value = HumanParams.ChanceToGetInfected;
    }

    public void SetChanceToGetInfected(float value)
    {
        _chanceToInfecteText.text = Math.Truncate(value * 100).ToString() + "%";
        HumanParams.ChanceToGetInfected = value;
    }
    //public float GetChanceToGetInfected() => _chanceToInfecteSlider.value;
}