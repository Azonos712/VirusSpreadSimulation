using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private SimulationSettingsController _sumulationSettings;
    [SerializeField] private AsyncSceneLoader _sceneLoader;

    public void StartSimulation()
    {
        CityParams.MaxHumansAtHome = _sumulationSettings.GetPopulation();
        CityParams.InitiallyInfectedPeople = _sumulationSettings.GetInfected();
        HumanParams.ChanceToGetInfected = _sumulationSettings.GetChanceToGetInfected();
        HumanParams.ChanceToWearMask = _sumulationSettings.GetChanceToWearMask();
        _sceneLoader.LoadLevel(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}