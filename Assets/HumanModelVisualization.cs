using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanModelVisualization : MonoBehaviour
{
    [SerializeField] private GameObject[] _humanModels;

    private void Awake()
    {
        //foreach (Transform t in transform)
        //Destroy(t.gameObject);

        //GameObject child = Instantiate(_humanModels[Random.Range(0, _humanModels.Length)]);
        var child = transform.GetChild(Random.Range(0, this.transform.childCount)).gameObject;
        child.SetActive(true);
        //child.transform.SetParent(transform, false);

        SetOutlineSettings(child);

        SetAnimationSettings(child);
    }

    private void SetOutlineSettings(GameObject child)
    {
        Outline outline = child.AddComponent<Outline>();
        outline.enabled = HealthStatusVisualization.Instance.IsEnable;
    }

    private void SetAnimationSettings(GameObject child)
    {
        child.AddComponent<HumanMovementAnimator>();
    }

}
