using System;
using UnityEngine;

public class UiSwitcher : MonoBehaviour
{
    public GameObject ObjectForEnable;

    public void SwitchVisibility()
    {
        ObjectForEnable.SetActive(!ObjectForEnable.activeSelf);
    }
}
