using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePlace : BasePlace
{
    //public int LocationRadius;
    [SerializeField] private GameObject _humanToSpawn;
    [SerializeField] private List<GameObject> _humans;
    private int _numberOfHumansToSpawn;
    private float _spawnTimer;

    private void Start()
    {
        _spawnTimer = Random.Range(5, 50);
        _numberOfHumansToSpawn = Random.Range(CityParams.MinHumansAtHome, CityParams.MaxHumansAtHome + 1);

        _placeCenter = GetComponent<Renderer>().bounds.center;
        _placeCenter.y = transform.localPosition.y;
    }

    void Update()
    {
        if (_spawnTimer <= 0f && _numberOfHumansToSpawn > 0)
        {
            var human = Instantiate(_humanToSpawn, _placeCenter, Quaternion.identity);

            human.GetComponent<HumanBehavior>().HomeObject = this.gameObject;


            _humans.Add(human);

            _numberOfHumansToSpawn--;
            _spawnTimer = Random.Range(5, 50);

            HumanStatistics.Instance?.IncreaseNumOfHumans();
        }
        _spawnTimer -= Time.deltaTime;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    if (_homeCenter != null)
    //        Gizmos.DrawWireSphere(_homeCenter, 0.1f);
    //}
}