using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettingsController : MonoBehaviour
{
    [SerializeField] private GameObject _confirmationBox;

    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private Resolution[] _resolutions;
    private int _resolutionIndex;

    [SerializeField] private TMP_Dropdown _qualityDropdown;
    [SerializeField] private Toggle _fullScreenToggle;

    private int _qualityLevel;
    private bool _isFoolScreen;

    public void Awake()
    {
        FillResolutionDropdown();

        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("masterQuality"));
        Screen.fullScreen = PlayerPrefs.GetInt("masterFullScreen") == 1 ? true : false;
        _isFoolScreen = Screen.fullScreen;
        _resolutionIndex = PlayerPrefs.GetInt("masterResolution");
        Resolution resolution = _resolutions[_resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, _isFoolScreen);
    }

    private void FillResolutionDropdown()
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

    public void OpenSettings()
    {
        _qualityDropdown.value = PlayerPrefs.GetInt("masterQuality");

        _fullScreenToggle.isOn = PlayerPrefs.GetInt("masterFullScreen") == 1 ? true : false;

        _resolutionDropdown.value = PlayerPrefs.GetInt("masterResolution");
    }

    public void SetResolution(int resolutionIndex)
    {
        _resolutionIndex = resolutionIndex;
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
        PlayerPrefs.SetInt("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);

        PlayerPrefs.SetInt("masterFullScreen", _isFoolScreen ? 1 : 0);
        Screen.fullScreen = _isFoolScreen;

        Resolution resolution = _resolutions[_resolutionIndex];
        PlayerPrefs.SetInt("masterResolution", _resolutionIndex);
        Screen.SetResolution(resolution.width, resolution.height, _isFoolScreen);

        _confirmationBox.active = false;
        _confirmationBox.active = true;
    }

    public void SettingsReset()
    {
        _qualityDropdown.value = 1;

        _fullScreenToggle.isOn = true;

        _resolutionDropdown.value = _resolutions.Length - 1;
    }
}