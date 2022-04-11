using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimulationSettingsController : MonoBehaviour
{
    [SerializeField] private TMP_Text _populationText;
    [SerializeField] private Slider _populationSlider;
    [SerializeField] private TMP_Text _infectedText;
    [SerializeField] private Slider _infectedSlider;
    [SerializeField] private TMP_Text _chanceToInfecteText;
    [SerializeField] private Slider _chanceToInfecteSlider;
    [SerializeField] private TMP_Text _chanceToWearMaskText;
    [SerializeField] private Slider _chanceToWearMaskSlider;

    public void SetPopulation(float value) => _populationText.text = "~" + ((120 + Math.Truncate(value) * 120) / 2).ToString();

    public int GetPopulation() => (int)Math.Truncate(_populationSlider.value);

    public void SetInfected(float value) => _infectedText.text = Math.Truncate(value).ToString();

    public int GetInfected() => (int)Math.Truncate(_infectedSlider.value);

    public void SetChanceToGetInfected(float value) => _chanceToInfecteText.text = Math.Truncate(value * 100).ToString() + "%";

    public float GetChanceToGetInfected() => _chanceToInfecteSlider.value;

    public void SetChanceToWearMask(float value) => _chanceToWearMaskText.text = Math.Truncate(value * 100).ToString() + "%";

    public float GetChanceToWearMask() => _chanceToWearMaskSlider.value;
}