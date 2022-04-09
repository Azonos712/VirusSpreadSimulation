using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsController : MonoBehaviour
{
    [SerializeField] private TMP_Text _volumeTextValue;
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private GameObject _confirmationBox;
    [SerializeField] private float _currentVolume;

    public void Awake()
    {
        AudioListener.volume = PlayerPrefs.HasKey("masterVolume") ? PlayerPrefs.GetFloat("masterVolume") : 1;
    }

    public void OpenSettings()
    {
        _volumeSlider.value = AudioListener.volume;
        _volumeTextValue.text = AudioListener.volume.ToString("0.0");
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

        _confirmationBox.SetActive(false);
        _confirmationBox.SetActive(true);
    }

    public void VolumeReset()
    {
        _volumeSlider.value = 1;
    }
}