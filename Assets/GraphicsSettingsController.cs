using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettingsController : MonoBehaviour
{
    [SerializeField] private GameObject _confirmationBox;

    [SerializeField] private Slider _brightnessSlider;
    [SerializeField] private TMP_Text _brightnessTextValue;
    [SerializeField] private float _defaultBrightness = 1;
    private float _brightnessLevel;

    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] Resolution[] _resolutions;

    private int _qualityLevel;
    private bool _isFoolScreen;

    private void Start()
    {
        _resolutions = Screen.resolutions;
        _resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + " x " + _resolutions[i].height;
            options.Add(option);

            if (_resolutions[i].width == Screen.width && _resolutions[i].height == Screen.height)
                currentResolutionIndex = i;
        }

        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.value = currentResolutionIndex;
        _resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetBrightness(float brightness)
    {
        _brightnessLevel = brightness;
        _brightnessTextValue.text = brightness.ToString("0.0");
    }

    public void SetFullScreen(bool value)
    {
        _isFoolScreen = value;
    }

    public void SetQuality(int index)
    {
        _qualityLevel = index;
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", _brightnessLevel);

        PlayerPrefs.SetInt("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);

        PlayerPrefs.SetInt("masterFullScreen", _isFoolScreen ? 1 : 0);
        Screen.fullScreen = _isFoolScreen;

        _confirmationBox.active = false;
        _confirmationBox.active = true;
    }
}