using UnityEngine;

[CreateAssetMenu(fileName = "UnitStats", menuName = "ScriptableObjects/UnitStatsConfig", order = 1)]
public class UnitStatsConfig : ScriptableObject
{
    [SerializeField] private int _health;
    public int Health => _health;
    [SerializeField] private int _attack;
    public int Attack => _attack;
    [SerializeField] private float _speed;
    public float Speed => _speed;
    [SerializeField] private float _attackSpeed;
    public float AttackSpeed => _attackSpeed;
}
