using UnityEngine;

public class AIObject : MonoBehaviour
{
    [SerializeField] protected HealthModule _healthModule;
    [SerializeField] protected UnitStatsConfig _config;
    
    public void TakeDamage(int damage)
    {
        _healthModule.TakeDamage(damage);
    }

    protected virtual void Death()
    {
    }
}
