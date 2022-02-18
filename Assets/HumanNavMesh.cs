using UnityEngine;
using UnityEngine.AI;

public class HumanNavMesh : MonoBehaviour
{
    private NavMeshPath _path;
    private NavMeshAgent _agent;
    private float _timer = 6f;
    [SerializeField] private GameObject _prevPoint;
    [SerializeField] private GameObject _nextPoint;
    [SerializeField] private Vector3 _targetPos;
    [SerializeField] private bool _arrived;
    public bool Arrived => _arrived;

    public NavMeshPathStatus PathStatus;
    public float RemainingDistance;
    public bool PathPending;
    public bool HasPath;

    void Awake()
    {
        _path = new NavMeshPath();
        _agent = GetComponent<NavMeshAgent>();
        _arrived = false;
    }

    void Update()
    {
        PathStatus = _agent.pathStatus;
        RemainingDistance = _agent.remainingDistance;
        PathPending = _agent.pathPending;
        HasPath = _agent.hasPath;

        if (_nextPoint == null)
            return;

        if (!_arrived)
        {
            if (_timer <= 0 && (!HasPath || PathStatus != NavMeshPathStatus.PathComplete))
                UpdatePath();

            _timer -= Time.deltaTime;

            if (Vector3.Distance(transform.position, _targetPos) <= _agent.stoppingDistance)
                _arrived = true;
        }

        //if (RemainingDistance != Mathf.Infinity && RemainingDistance <= _agent.stoppingDistance &&
        //    PathStatus == NavMeshPathStatus.PathComplete && !HasPath) //Arrived.
        //    _arrived = true;

        //if (!_agent.pathPending && _agent.remainingDistance <= 1f && _nextPoint != null)
        //    GoToNextPoint();

    }

    private void UpdatePath()
    {
        if (_agent.CalculatePath(_targetPos, _path))
            _agent.SetPath(_path);
        //else
        //UnityEngine.Debug.LogWarning($"(UpdatePath) {this.gameObject.name}-{this.gameObject.transform.position}");

        _timer = 6f;
    }

    public void SetNextDestination(GameObject nextPoint)
    {
        _prevPoint = _nextPoint;
        _nextPoint = nextPoint;

        //Renderer renderer;
        //if (!_nextPoint.TryGetComponent<Renderer>(out renderer))
        //    renderer = _nextPoint.GetComponentInChildren<Renderer>();

        _targetPos = getCenter(_nextPoint.transform);//renderer.bounds.center;//_nextPoint.GetComponent<Renderer>().bounds.center;
        _targetPos.y -= 2;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(_targetPos, out hit, 2.5f, NavMesh.AllAreas))
            _targetPos = hit.position; //_targetPos.y += 0.2f;

        if (_agent.CalculatePath(_targetPos, _path))//&& _path.status == NavMeshPathStatus.PathComplete
            _agent.SetPath(_path);
        //else
        //UnityEngine.Debug.LogWarning($"(SetNextDestination) {this.gameObject.transform.position}");

        _arrived = false;

        //_agent.CalculatePath(point, _path);
        //_agent.SetDestination(point);
        //NavMesh.CalculatePath(transform.position, _nextPoint.transform.position, NavMesh.AllAreas, _path);
    }

    public void SetNextTargetInDestinationArea(Vector3 nextTarget)
    {
        _targetPos = getCenter(_nextPoint.transform);//_nextPoint.GetComponent<Renderer>().bounds.center;
        _targetPos.x += nextTarget.x;
        _targetPos.y -= 2;
        _targetPos.z += nextTarget.z;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(_targetPos, out hit, 2.5f, NavMesh.AllAreas))
            _targetPos = hit.position;

        if (_agent.CalculatePath(_targetPos, _path))
            _agent.SetPath(_path);
        //else
        //UnityEngine.Debug.LogWarning($"(SetNextDestination) {this.gameObject.transform.position}");

        _arrived = false;
    }

    Vector3 getCenter(Transform obj)
    {
        Vector3 center = new Vector3();
        if (obj.GetComponent<Renderer>() != null)
        {
            center = obj.GetComponent<Renderer>().bounds.center;
        }
        else
        {
            foreach (Transform subObj in obj)
            {
                center += getCenter(subObj);
            }
            center /= obj.childCount;
        }
        return center;
    }
}
