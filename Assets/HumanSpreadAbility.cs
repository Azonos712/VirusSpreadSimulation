using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpreadAbility : MonoBehaviour
{
    private HumanHealth _humanHealth;
    [SerializeField] private float _spreadRadius = 1.5f;
    [SerializeField] private float _timeRemainingToNextSpreadTick;

    public Vector3 SpreadCenter => transform.position + Vector3.up;

    void Start()
    {
        _humanHealth = GetComponent<HumanHealth>();
        _spreadRadius = Random.Range(HumanParams.MinSpreadRadius, HumanParams.MaxSpreadRadius);
        _timeRemainingToNextSpreadTick = Random.Range(HumanParams.MinSpreadTick, HumanParams.MaxSpreadTick);
    }

    void Update()
    {
        if (_humanHealth.Status == HealthStatus.Infected)
        {
            SpreadTimer();
        }
    }

    private void SpreadTimer()
    {
        if (_timeRemainingToNextSpreadTick <= 0)
        {
            Spread();
            _timeRemainingToNextSpreadTick = Random.Range(HumanParams.MinSpreadTick, HumanParams.MaxSpreadTick);
        }

        _timeRemainingToNextSpreadTick -= Time.deltaTime;
    }

    private void Spread()
    {
        Collider[] hitColliders = Physics.OverlapSphere(SpreadCenter, _spreadRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.TryGetComponent<HumanHealth>(out HumanHealth humanHealth))
            {
                if (humanHealth != _humanHealth)
                {
                    humanHealth.TryToInfect(_humanHealth);
                    //Debug.Log($"I am {this.gameObject.name}, and in my area {hitCollider.gameObject.name}");
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(SpreadCenter, _spreadRadius);
    }
}
