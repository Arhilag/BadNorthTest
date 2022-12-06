using System;
using UnityEngine;

public class AIInput : MonoBehaviour
{
    [SerializeField] private ListHouse _listHouse;

    private void Start()
    {
        EnemySpawner.OnSpawnSquad += Move;
    }

    private void OnDestroy()
    {
        EnemySpawner.OnSpawnSquad -= Move;
    }

    private void Move(EnemySquad squad)
    {
        squad.SetListTarget(_listHouse);
    }
}

[Serializable]
public struct ListHouse
{
    public Transform[] Houses;
}
