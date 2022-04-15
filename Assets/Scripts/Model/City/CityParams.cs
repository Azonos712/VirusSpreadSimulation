using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityParams
{
    public static bool NewSimulation { get; set; } = false;
    public static int MinHumansAtHome { get; } = 1;
    public static int MaxHumansAtHome { get; set; } = 4;
    public static int MinHumansWorkTime { get; } = 100;
    public static int MaxHumansWorkTime { get; } = 240;
    public static int MinHumansRestTime { get; } = 100;
    public static int MaxHumansRestTime { get; } = 240;
    public static int MinHumansActivityTime { get; } = 10;
    public static int MaxHumansActivityTime { get; } = 70;
    public static int InitiallyInfectedPeople { get; set; } = 1;
}