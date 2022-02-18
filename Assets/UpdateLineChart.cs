using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XCharts;

public class UpdateLineChart : MonoBehaviour
{
    private float updateTime = 100;
    private LineChart chart;
    private DayNightCycle _dayNightCycle;
    void Awake()
    {
        chart = gameObject.GetComponentInChildren<LineChart>();
        _dayNightCycle = FindObjectOfType<DayNightCycle>();
    }

    void Update()
    {
        updateTime += Time.deltaTime;
        //if (Math.Round(_dayNightCycle.DaysHavePassed, 1) % 0.1f == 0)
        if (updateTime >= 70)
        {
            updateTime = 0;

            if (HumanStatistics.Instance.HumanCount == 0)
                chart.series.SetActive(0, false);
            else if (!chart.series.IsActive(0))
                chart.series.SetActive(0, true);

            chart.AddXAxisData(_dayNightCycle.DaysHavePassed.ToString("0.0") + " сутки");
            chart.AddData(0, HumanStatistics.Instance.HealthyHumanCount);
            chart.AddData(1, HumanStatistics.Instance.InfectedHumanCount);
            chart.AddData(2, HumanStatistics.Instance.RecoveredHumanCount);
            chart.RefreshChart();
        }
    }
}
