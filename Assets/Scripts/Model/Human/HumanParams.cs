public static class HumanParams
{
    public static float MinSpeed { get; } = 1.8f;
    public static float MaxSpeed { get; } = 5.5f;
    public static float MinSpreadRadius { get; } = 1.4f;
    public static float MaxSpreadRadius { get; } = 1.60f; //1.75
    public static float MinSpreadTick { get; } = 20f;//60
    public static float MaxSpreadTick { get; } = 60f;//300
    public static float MinInfectedTime { get; } = 600f;//60
    public static float MaxInfectedTime { get; } = 1000f;//300
    public static float ChanceToGetInfected { get; set; } = 0.8f;
    public static float ChanceToWearMask { get; set; } = 0.2f;
    public static float ChanceToGoOnIsolation { get; set; } = 0.0f;
}