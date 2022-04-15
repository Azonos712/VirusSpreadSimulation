using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private SimulationSettingsController _sumulationSettings;
    [SerializeField] private AsyncSceneLoader _sceneLoader;

    private void Awake()
    {
        CityParams.NewSimulation = false;
    }

    public void StartSimulation()
    {
        CityParams.NewSimulation = true;
        CityParams.MaxHumansAtHome = _sumulationSettings.GetPopulation();
        CityParams.InitiallyInfectedPeople = _sumulationSettings.GetInfected();
        HumanParams.ChanceToGetInfected = _sumulationSettings.GetChanceToGetInfected();
        HumanParams.ChanceToWearMask = _sumulationSettings.GetChanceToWearMask();
        HumanParams.ChanceToGoOnIsolation = _sumulationSettings.GetChanceToIsolation();
        _sceneLoader.LoadLevel(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}