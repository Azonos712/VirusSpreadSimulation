using UnityEngine;
using System.Collections;
using RTS_Cam;
using System;

[RequireComponent(typeof(RTS_Camera))]
public class TargetSelector : MonoBehaviour
{
    private RTS_Camera cam;
    private new Camera camera;
    public string targetsTag;
    private HumanModelVisualization _lastObject;

    private void Start()
    {
        cam = gameObject.GetComponent<RTS_Camera>();
        camera = gameObject.GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                _lastObject?.DeselectThisObject();
                if (hit.transform.CompareTag(targetsTag))
                {
                    cam.SetTarget(hit.transform);
                    _lastObject = hit.transform.root.gameObject.GetComponentInChildren<HumanModelVisualization>();
                    _lastObject?.SelectThisObject();
                }
                else
                {
                    cam.ResetTarget();
                }
            }
        }
    }
}