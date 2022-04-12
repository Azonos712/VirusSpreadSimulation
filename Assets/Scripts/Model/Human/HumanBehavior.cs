using UnityEngine;

[SelectionBase]
public class HumanBehavior : MonoBehaviour
{
    private HumanNavMesh _navMesh;
    private HumanHealth _health;
    [SerializeField] private HumanStateId _currentState; // просто для отображения
    private HumanStateMachine _stateMachine;
    [SerializeField] private GameObject _currentObject;
    [SerializeField] private GameObject _previousObject;
    [SerializeField] private GameObject _workObject;
    [SerializeField] private GameObject _homeObject;
    [SerializeField] private GameObject _activityObject;
    private WorkPlace _work;
    private HomePlace _home;
    private ActivityPlace _activity;

    public HealthStatus HealthStatus => _health.Status;

    public float TimeRemainingInCurrentState;
    public bool Arrived => _navMesh.Arrived;
    public HumanStateMachine StateMachine => _stateMachine;
    public GameObject CurrentObject => _currentObject;
    public GameObject PreviousObject => _previousObject;
    public GameObject WorkObject
    {
        get => _workObject;
        set
        {
            _workObject = value;
            _work = _workObject.GetComponent<WorkPlace>();
        }
    }
    public GameObject HomeObject
    {
        get => _homeObject;
        set
        {
            _homeObject = value;
            _home = _homeObject.GetComponent<HomePlace>();
        }
    }
    public GameObject ActivityObject
    {
        get => _activityObject;
        set
        {
            _activityObject = value;
            _activity = _activityObject.GetComponent<ActivityPlace>();
        }
    }
    public WorkPlace Work => _work;
    public HomePlace Home => _home;
    public ActivityPlace Activity => _activity;

    void Start()
    {
        _navMesh = GetComponent<HumanNavMesh>();
        _health = GetComponent<HumanHealth>();

        _stateMachine = new HumanStateMachine(this);
        _stateMachine.RegisterState(new SpawnState());
        _stateMachine.RegisterState(new WorkState());
        _stateMachine.RegisterState(new GoToWorkState());
        _stateMachine.RegisterState(new HomeState());
        _stateMachine.RegisterState(new GoToHomeState());
        _stateMachine.RegisterState(new ActivityState());
        _stateMachine.RegisterState(new GoToActivityState());

        _stateMachine.ChangeState(HumanStateId.Spawn);
    }

    void Update()
    {
        _stateMachine.Update();
        _currentState = _stateMachine.CurrentState;
    }

    public void SetNextDestination(GameObject nextDestination)
    {
        _navMesh.SetNextDestination(nextDestination);
        _previousObject = _currentObject;
        _currentObject = nextDestination;
    }

    public void SetNextTargetInDestinationArea(Vector3 point)
    {
        _navMesh.SetNextTargetInDestinationArea(point);
    }
}
