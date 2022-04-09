using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{
    public void DisableThisObject()
    {
        gameObject.active = false;
    }
}
