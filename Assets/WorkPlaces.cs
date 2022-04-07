using System;
using System.Collections.ObjectModel;
using UnityEngine;

public class WorkPlaces : MonoBehaviour
{
    private static WorkPlace[] _workPlaces;
    public static ReadOnlyCollection<WorkPlace> List
    {
        get
        {
            if (_workPlaces == null)
                _workPlaces = FindObjectsOfType<WorkPlace>();

            return Array.AsReadOnly(_workPlaces);
        }
    }

    private void Awake()
    {
        _workPlaces = FindObjectsOfType<WorkPlace>();
    }
}
