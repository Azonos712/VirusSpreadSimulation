using UnityEngine;

public class UiVisualizer : MonoBehaviour
{
    public CanvasGroup[] ObjectForVisible;

    public void SwitchVisibility()
    {
        foreach (var obj in ObjectForVisible)
            obj.alpha = (int)obj.alpha ^ 1;
    }
}
