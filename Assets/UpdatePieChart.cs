using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class UpdatePieChart : MonoBehaviour
{
    private float updateTime = 3;
    BaseChart chart;
    void Awake()
    {
        chart = gameObject.GetComponent<BaseChart>();
    }

    void Update()
    {
        updateTime += Time.deltaTime;
        if (chart && updateTime > 2)
        {
            updateTime = 0;
            var serie = chart.series.GetSerie(0);
            //serie.animation.dataChangeEnable = true;
            var dataCount = serie.dataCount;

            if (HumanStatistics.Instance.HumanCount == 0)
                chart.series.SetActive(0, false);
            else if (!chart.series.IsActive(0))
                chart.series.SetActive(0, true);

            chart.UpdateData(0, 0, HumanStatistics.Instance.HealthyHumanCount);
            chart.UpdateData(0, 1, HumanStatistics.Instance.InfectedHumanCount);
            chart.UpdateData(0, 2, HumanStatistics.Instance.RecoveredHumanCount);

        }
    }
}
