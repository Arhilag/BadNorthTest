using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class UnitAI : AIObject
{
    [SerializeField] private SeeModule _seeModule;
    [SerializeField] private FightModule _fightModule;
    [SerializeField] private NavMeshAgent _navMesh;
    [SerializeField] private float _maxFightDistance = 0.3f;
    [SerializeField] private float _coroutineFrequency = 0.2f;

    private Vector3 _targetPanel;
    private Transform _targetEnemy;
    private AIObject _targetAI;
    private int _attack;
    private float _attackSpeed;
    
    private enum UnitState
    {
        Move,
        Attack,
        Pursuit
    }

    private UnitState _state = UnitState.Move;

    public Action<UnitAI> OnDeadUnit;

    private void Awake()
    {
        _healthModule.OnDead += Death;
        _seeModule.OnTargetMove += StartPursuit;
        _fightModule.OnTargetFight += Fight;
        _healthModule.Init(_config.Health);
        _navMesh.speed = _config.Speed;
        _attack = _config.Attack;
        _attackSpeed = _config.AttackSpeed;
    }

    private void OnDestroy()
    {
        _healthModule.OnDead -= Death;
        _seeModule.OnTargetMove -= StartPursuit;
        _fightModule.OnTargetFight -= Fight;
    }

    private void Fight(AIObject targetAI, Transform targetTransform)
    {
        _fightModule.gameObject.SetActive(false);
        _targetEnemy = targetTransform;
        _targetAI = targetAI;
        _state = UnitState.Attack;
        StartCoroutine(TakeDistance());
        StartCoroutine(Attack());
    }

    private void StartPursuit(Transform target)
    {
        _seeModule.gameObject.SetActive(false);
        _fightModule.gameObject.SetActive(true);
        _targetEnemy = target;
        _state = UnitState.Pursuit;
        StartCoroutine(Pursuit());
    }

    private IEnumerator Pursuit()
    {
        while (_state == UnitState.Pursuit)
        {
            if (_targetEnemy.gameObject.activeSelf == false)
            {
                MoveToTarget();
                break;
            }
            _navMesh.destination = _targetEnemy.position;
            yield return new WaitForSeconds(_coroutineFrequency);
        }
    }
    
    private IEnumerator TakeDistance()
    {
        float dist;
        while (_state == UnitState.Attack)
        {
            if (_targetEnemy.gameObject.activeSelf == false)
            {
                MoveToTarget();
                break;
            }
            dist = Vector3.Distance(_navMesh.gameObject.transform.position, _targetEnemy.position);
            if(dist > _maxFightDistance)
                _navMesh.destination = _targetEnemy.position;
            yield return new WaitForSeconds(_coroutineFrequency);
        }
    }

    private IEnumerator Attack()
    {
        while (_state == UnitState.Attack)
        {
            if (_targetEnemy.gameObject.activeSelf == false)
            {
                MoveToTarget();
                break;
            }
            _targetAI.TakeDamage(_attack);
            yield return new WaitForSeconds(_attackSpeed);
        }
    }

    private void MoveToTarget()
    {
        _state = UnitState.Move;
        if (gameObject.activeSelf == true)
        {
            _navMesh.destination = _targetPanel;
        }
        _seeModule.gameObject.SetActive(true);
    }
    
    public void SetTarget(Vector3 target)
    {
        _targetPanel = target;
        MoveToTarget();
    }
    
    protected override void Death()
    {
        gameObject.SetActive(false);
        OnDeadUnit?.Invoke(this);
    }

    public void EnableNavMesh(bool flag)
    {
        _navMesh.enabled = flag;
    }
}
