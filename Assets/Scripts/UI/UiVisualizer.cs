using UnityEngine;

public class UiVisualizer : MonoBehaviour
{
    [SerializeField] private RectTransform _transform;
    [SerializeField] private Vector3 _defaultPosition;
    [SerializeField] private float _offsetX;
    [SerializeField] private CanvasGroup[] _objectForVisible;

    public void Start()
    {
        _defaultPosition = _transform.localPosition;
    }

    public void SwitchVisibility()
    {
        if (_objectForVisible[0].alpha == 0)
            _transform.localPosition = new Vector3(_transform.localPosition.x + _offsetX, _transform.localPosition.y, _transform.localPosition.z);
        else
            _transform.localPosition = new Vector3(_transform.localPosition.x - _offsetX, _transform.localPosition.y, _transform.localPosition.z);

        foreach (var obj in _objectForVisible)
            obj.alpha = (int)obj.alpha ^ 1;
    }

    public void HidePanel() => _transform.localPosition = _defaultPosition;
}