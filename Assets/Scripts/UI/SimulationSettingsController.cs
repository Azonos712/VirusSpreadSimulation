using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimulationSettingsController : MonoBehaviour
{
    [SerializeField] private TMP_Text _infectedText;
    [SerializeField] private Slider _infectedSlider;
    [SerializeField] private TMP_Text _chanceToInfecteText;
    [SerializeField] private Slider _chanceToInfecteSlider;

    public void SetInfected(float value) => _infectedText.text = Math.Truncate(value).ToString();

    public int GetInfected() => (int)Math.Truncate(_infectedSlider.value);

    public void SetChanceToGetInfected(float value) => _chanceToInfecteText.text = Math.Truncate(value * 100).ToString() + "%";

    public float GetChanceToGetInfected() => _chanceToInfecteSlider.value;
}