using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Outline;

public class HealthStatusVisualization : MonoBehaviour
{
    private static HealthStatusVisualization _instance;
    public static HealthStatusVisualization Instance { get { return _instance; } }

    [SerializeField] private bool _isEnable = false;
    public bool IsEnable => _isEnable;

    [SerializeField] private Mode _mode = Mode.OutlineVisible;
    public Mode Mode => _mode;

    void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void ToggleHealthStatusDisplay()
    {
        var foundHumansOutline = FindObjectsOfType<Outline>();

        foreach (var humanOutline in foundHumansOutline)
        {
            humanOutline.enabled = !humanOutline.enabled;
        }

        _isEnable = !_isEnable;
    }

    public void ToggleXRayDisplay()
    {
        if (_mode == Mode.OutlineVisible)
            _mode = Mode.OutlineAll;
        else
            _mode = Mode.OutlineVisible;

        var foundHumansOutline = FindObjectsOfType<Outline>();

        foreach (var humanOutline in foundHumansOutline)
        {
            humanOutline.OutlineMode = _mode;
        }
    }
}
