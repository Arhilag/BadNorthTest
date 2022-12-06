using System;
using System.Collections.Generic;
using UnityEngine;

public class Squad : ActiveObject
{
    [SerializeField] protected List<UnitAI> _units;
    [SerializeField] private UnitAI _unitPrefab;
    [SerializeField] private DeploymentConfig _deploymentConfig;
    [SerializeField] private int _countUnits;

    public static Action<string> OnDeadSquad;
    
    public override void MoveToPanel(Vector3 target)
    {
        for (int i = 0; i < _units.Count; i++)
        {
            _units[i].SetTarget(target + _deploymentConfig.Positions[i]);
        }
    }

    private void Start()
    {
        SpawnUnits();
        AddStart();
    }

    private void SpawnUnits()
    {
        for (int i = 0; i < _countUnits; i++)
        {
            var newUnit = Instantiate(_unitPrefab, 
                transform.position + _deploymentConfig.Positions[i], transform.rotation);
            _units.Add(newUnit);
            newUnit.OnDeadUnit += DeathUnit;
        }
    }

    protected virtual void AddStart()
    {
    }
    
    private void DeathUnit(UnitAI unit)
    {
        unit.OnDeadUnit -= DeathUnit;
        _units.Remove(unit);
        if (_units.Count == 0)
        {
            OnDeadSquad?.Invoke(gameObject.tag);
        }
    }
}
