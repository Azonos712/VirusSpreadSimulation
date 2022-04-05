using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettingsController : MonoBehaviour
{
    [SerializeField] private GameObject _confirmationBox;

    [SerializeField] private Toggle _fullScreenToggle;
    private bool _isFoolScreen;

    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private Resolution[] _resolutions;
    private int _resolutionIndex;
    private int _newResolutionIndex;

    [SerializeField] private TMP_Dropdown _qualityDropdown;
    private int _qualityLevel;


    public void Awake()
    {
        FillResolutionDropdown();

        _isFoolScreen = PlayerPrefs.HasKey("masterFullScreen") ? (PlayerPrefs.GetInt("masterFullScreen") == 1 ? true : false) : true;
        Screen.fullScreen = _isFoolScreen;

        _resolutionIndex = PlayerPrefs.HasKey("masterResolution") ? PlayerPrefs.GetInt("masterResolution") : _resolutions.Length - 1;
        Resolution resolution = _resolutions[_resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, _isFoolScreen);

        _qualityLevel = PlayerPrefs.HasKey("masterQuality") ? PlayerPrefs.GetInt("masterQuality") : 3;
        QualitySettings.SetQualityLevel(_qualityLevel);
    }

    private void FillResolutionDropdown()
    {
        _resolutions = Screen.resolutions;
        _resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].ToString();// _resolutions[i].width + " x " + _resolutions[i].height + " @ " + _resolutions[i].refreshRate;
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
        _fullScreenToggle.isOn = Screen.fullScreen;
        _resolutionDropdown.value = _resolutionIndex;
        _qualityDropdown.value = QualitySettings.GetQualityLevel();
    }

    public void SetFullScreen(bool value)
    {
        _isFoolScreen = value;
    }

    public void SetResolution(int resolutionIndex)
    {
        _newResolutionIndex = resolutionIndex;
    }

    public void SetQuality(int index)
    {
        _qualityLevel = index;
    }

    public void GraphicsApply()
    {
        PlayerPrefs.SetInt("masterFullScreen", _isFoolScreen ? 1 : 0);
        Screen.fullScreen = _isFoolScreen;

        Resolution resolution = _resolutions[_newResolutionIndex];
        PlayerPrefs.SetInt("masterResolution", _newResolutionIndex);
        _resolutionIndex = _newResolutionIndex;
        Screen.SetResolution(resolution.width, resolution.height, _isFoolScreen);

        PlayerPrefs.SetInt("masterQuality", _qualityLevel);
        QualitySettings.SetQualityLevel(_qualityLevel);

        _confirmationBox.active = false;
        _confirmationBox.active = true;
    }

    public void SettingsReset()
    {
        _fullScreenToggle.isOn = true;
        _resolutionDropdown.value = _resolutions.Length - 1;
        _qualityDropdown.value = 1;
    }
}