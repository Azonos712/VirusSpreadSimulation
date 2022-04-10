using System;
using UnityEngine;

public enum HealthStatus
{
    Healthy,
    Infected,
    Recovered
}

public class HumanHealth : MonoBehaviour
{
    public event Action<HealthStatus> OnStatusChanged;

    [SerializeField] private HealthStatus _status;
    public HealthStatus Status
    {
        get
        {
            return _status;
        }
        private set
        {
            _status = value;

            if (_status == HealthStatus.Infected)
                TimeToRecovery = UnityEngine.Random.Range(HumanParams.MinInfectedTime, HumanParams.MaxInfectedTime);

            OnStatusChanged?.Invoke(_status);
        }
    }

    public float TimeToRecovery = 0f;

    public bool HasMask;

    void Start()
    {
        Status = HealthStatus.Healthy;

        if (CityParams.InitiallyInfectedPeople > 0)
        {
            CityParams.InitiallyInfectedPeople--;
            Status = HealthStatus.Infected;
            HumanStatistics.Instance?.IncreaseNumOfInfectedHumans();
        }

        if (UnityEngine.Random.value < HumanParams.ChanceToWearMask)
            HasMask = true;

    }

    void Update()
    {
        if (Status == HealthStatus.Infected)
        {
            BeSick();
        }
    }

    private void BeSick()
    {
        if (TimeToRecovery <= 0)
        {
            Status = HealthStatus.Recovered;
            HumanStatistics.Instance?.IncreaseNumOfRecoveredHumans();
            HumanStatistics.Instance?.DecreaseNumOfInfectedHumans();
        }

        TimeToRecovery -= Time.deltaTime;
    }

    public void TryToInfect(HumanHealth anotherHuman)
    {
        if (Status == HealthStatus.Healthy)
        {
            var chance = HumanParams.ChanceToGetInfected;

            if (this.HasMask)
                chance /= 1.5f;

            if (anotherHuman.HasMask)
                chance /= 3f;

            if (UnityEngine.Random.value < chance)
            {
                Status = HealthStatus.Infected;
                HumanStatistics.Instance?.IncreaseNumOfInfectedHumans();
            }
        }
    }
}