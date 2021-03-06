using System;
using System.Collections.ObjectModel;
using UnityEngine;

public class ActivityPlaces : MonoBehaviour
{
    private static ActivityPlace[] _activityPlaces;
    public static ReadOnlyCollection<ActivityPlace> List
    {
        get
        {
            if (_activityPlaces == null)
                _activityPlaces = FindObjectsOfType<ActivityPlace>();

            return Array.AsReadOnly(_activityPlaces);
        }
    }

    private void Awake()
    {
        _activityPlaces = FindObjectsOfType<ActivityPlace>();
    }
}
