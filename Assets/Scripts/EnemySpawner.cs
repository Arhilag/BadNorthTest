using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnerConfig _config;
    [SerializeField] private EnemySquad _squadPrefab;
    public static Action<EnemySquad> OnSpawnSquad;
    public static Action OnSpawnEnemySquad;
    public static Action OnLastWave;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < _config.Wave.Length; i++)
        {
            for (int j = 0; j < _config.Wave[i].CountEnemySquads; j++)
            {
                var x = Random.Range(-4, 5);
                var y = 4.5f;
                var squad = Instantiate(_squadPrefab, new Vector3(x, 0, y+2.5f), transform.rotation);
                squad.SetSwimTarget(new Vector3(x, 0, y));
                OnSpawnSquad?.Invoke(squad);
                OnSpawnEnemySquad?.Invoke();
            }

            yield return new WaitForSeconds(_config.Wave[i].DelayBeforeNext);
        }
        OnLastWave?.Invoke();
    }
}
