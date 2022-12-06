using System;
using UnityEngine;

public class HouseAI : AIObject
{
    [SerializeField] private GameObject _fullHouse;
    [SerializeField] private GameObject _destroyedHouse;
    public static Action OnDestroyHouse;
    private void Awake()
    {
        _healthModule.OnDead += Death;
        _healthModule.Init(_config.Health);
    }

    private void OnDestroy()
    {
        _healthModule.OnDead -= Death;
    }

    protected override void Death()
    {
        OnDestroyHouse?.Invoke();
        gameObject.SetActive(false);
        _destroyedHouse.SetActive(true);
        _fullHouse.SetActive(false);
    }
}
