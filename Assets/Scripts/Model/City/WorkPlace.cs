using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkPlace : BasePlace
{
    [SerializeField] private int _maxNumOfWorkers = 2;
    public int MaxNumOfWorkers => _maxNumOfWorkers;
    public List<GameObject> ListOfWorkers;
    [SerializeField] private int _currentNumOfPeople;

    void Start()
    {
        ListOfWorkers = new List<GameObject>(MaxNumOfWorkers);
    }

    public void IncreaseNumOfPeople()
    {
        _currentNumOfPeople++;
    }

    public void DecreaseNumOfPeople()
    {
        _currentNumOfPeople--;
    }
}
