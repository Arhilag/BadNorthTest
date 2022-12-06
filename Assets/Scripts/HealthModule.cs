using System;
using UnityEngine;

public class HealthModule : MonoBehaviour
{
    private int _health;
    private int _maxHealth;
    public Action OnDead;
    public Action<int, int> OnChangeHealth;

    public void Init(int maxHealth)
    {
        _maxHealth = maxHealth;
        _health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        OnChangeHealth?.Invoke(_health, _maxHealth);
        if (_health <= 0)
        {
            OnDead?.Invoke();
        }
    }
}
