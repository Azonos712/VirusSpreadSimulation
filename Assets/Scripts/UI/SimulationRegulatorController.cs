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
    [SerializeField] private TMP_Text _chanceToIsolationText;
    [SerializeField] private Slider _chanceToIsolationSlider;

    private void Awake()
    {
        _chanceToInfecteSlider.value = HumanParams.ChanceToGetInfected;
        _chanceToWearMaskSlider.value = HumanParams.ChanceToWearMask;
        _chanceToIsolationSlider.value = HumanParams.ChanceToGoOnIsolation;
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

    public void SetChanceToIsolation(float value)
    {
        _chanceToIsolationText.text = Math.Truncate(value * 100).ToString() + "%";
        HumanParams.ChanceToGoOnIsolation = value;
    }
}