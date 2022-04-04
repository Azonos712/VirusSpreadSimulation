using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsController : MonoBehaviour
{
    [SerializeField] private TMP_Text _volumeTextValue;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private GameObject _confirmationBox;
    [SerializeField] private float _currentVolume;
    [SerializeField] private float _defaultVolume;
    private WaitForSeconds _sleepTime = new WaitForSeconds(2);

    public void OpenSettings()
    {
        _volumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
    }

    public void SetVolume(float volume)
    {
        _currentVolume = volume;
        _volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        AudioListener.volume = _currentVolume;
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public void VolumeReset()
    {
        AudioListener.volume = _defaultVolume;
        _volumeSlider.value = _defaultVolume;
    }

    public IEnumerator ConfirmationBox()
    {
        _confirmationBox.SetActive(true);
        yield return _sleepTime;
        _confirmationBox.SetActive(false);
    }
}
