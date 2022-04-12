using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimulationRegulatorController : MonoBehaviour
{
    [SerializeField] private TMP_Text _chanceToInfecteText;
    [SerializeField] private Slider _chanceToInfecteSlider;
    [SerializeField] private TMP_Text _chanceToWearMaskText;
    [SerializeField] private Slider _chanceToWearMaskSlider;

    private void Awake()
    {
        _chanceToInfecteSlider.value = HumanParams.ChanceToGetInfected;
        _chanceToWearMaskSlider.value = HumanParams.ChanceToWearMask;
    }

    public void SetChanceToGetInfected(float value)
    {
        _chanceToInfecteText.text = Math.Truncate(value * 100).ToString() + "%";
        HumanParams.ChanceToGetInfected = value;
    }

    public void SetChanceToWearMask(float value)
    {
        _chanceToWearMaskText.text = Math.Truncate(value * 100).ToString() + "%";
        HumanParams.ChanceToWearMask = value;
    }
}