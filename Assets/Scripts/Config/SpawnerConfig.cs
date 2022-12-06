using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Spawner", menuName = "ScriptableObjects/SpawnerConfig", order = 2)]
public class SpawnerConfig : ScriptableObject
{
    [SerializeField] private WaveSettings[] _wave;
    public WaveSettings[] Wave => _wave;
}

[Serializable]
public struct WaveSettings
{
    public int CountEnemySquads;
    public int DelayBeforeNext;
}
