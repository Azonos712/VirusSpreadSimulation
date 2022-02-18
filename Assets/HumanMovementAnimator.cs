using UnityEngine;
using UnityEngine.AI;

public class HumanMovementAnimator : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private SkinnedMeshRenderer _renderer;
    private float _timer = 0.4f;

    void Start()
    {
        _agent = GetComponentInParent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponentInChildren<SkinnedMeshRenderer>();

        AgentSpeedSettings();
    }

    private void AgentSpeedSettings()
    {
        var rnd = Random.value;
        int slowModifier = GetRandomSlowModifier(rnd);
        _agent.speed = Random.Range(HumanParams.MinSpeed, HumanParams.MaxSpeed - slowModifier);
    }

    private int GetRandomSlowModifier(float value)
    {
        if (value <= 0.15f)
            return 0;
        else if (value <= 0.30f)
            return 1;
        else if (value <= 0.45f)
            return 2;
        else
            return 3;
    }

    void Update()
    {
        if (_timer <= 0 && _renderer.isVisible)
        {
            _animator.SetFloat("Speed", _agent.velocity.magnitude / HumanParams.MaxSpeed);
            _timer = 0.4f;
        }
        _timer -= Time.deltaTime;
    }
}
