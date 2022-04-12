using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanStatistics : MonoBehaviour
{
    private static HumanStatistics _instance;
    public static HumanStatistics Instance { get { return _instance; } }

    [SerializeField] private int _humanCount = 0;
    public int HumanCount => _humanCount;

    [SerializeField] private int _healthyHumanCount = 0;
    public int HealthyHumanCount => _humanCount - _infectedHumanCount - _recoveredHumanCount;

    [SerializeField] private int _infectedHumanCount = 0;
    public int InfectedHumanCount => _infectedHumanCount;

    [SerializeField] private int _recoveredHumanCount = 0;
    public int RecoveredHumanCount => _recoveredHumanCount;

    void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;

        //DontDestroyOnLoad(gameObject);// Теперь нам нужно указать, чтобы объект не уничтожался при переходе на другую сцену игры

        Initialize();// И запускаем собственно инициализатор
    }

    private void Initialize()
    {
        /* TODO: Здесь мы будем проводить инициализацию */
    }

    public void IncreaseNumOfHumans() => _humanCount++;
    public void IncreaseNumOfInfectedHumans() => _infectedHumanCount++;
    public void DecreaseNumOfInfectedHumans() => _infectedHumanCount--;
    public void IncreaseNumOfRecoveredHumans() => _recoveredHumanCount++;
}
