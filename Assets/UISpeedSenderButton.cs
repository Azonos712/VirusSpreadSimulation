using UnityEngine;
using UnityEngine.UI;

public class UISpeedSenderButton : MonoBehaviour
{
    private UISpeedSettings _speedSettings;
    private Toggle _toggle;
    [SerializeField] private KeyCode _keyCode;

    private void Start()
    {
        _speedSettings = GetComponentInParent<UISpeedSettings>();
        _toggle = GetComponent<Toggle>();

        SwitchColors();
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(_keyCode))
                _toggle.isOn = true;
        }
    }

    public void SendButtonKeyCode()
    {
        if (_toggle.isOn)
            _speedSettings.ChangeSpeed(_keyCode);

        SwitchColors();
    }

    public void SwitchColors()
    {
        ColorBlock cb = _toggle.colors;
        if (_toggle.isOn)
        {
            cb.normalColor = Color.gray;
            cb.highlightedColor = Color.gray;
        }
        else
        {
            cb.normalColor = Color.white;
            cb.highlightedColor = Color.white;
        }
        _toggle.colors = cb;
    }
}
