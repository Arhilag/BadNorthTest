using UnityEngine;

public class GameResultController : MonoBehaviour
{
    [SerializeField] private int _countPlayerSquad = 2;
    [SerializeField] private int _countHouse = 2;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;

    private int _countEnemySquad;
    private bool _canWin = false;
    
    private void Awake()
    {
        EnemySpawner.OnLastWave += OnLastWave;
        EnemySpawner.OnSpawnEnemySquad += OnSpawnEnemy;
        HouseAI.OnDestroyHouse += OnDestroyHouse;
        Squad.OnDeadSquad += OnDeadSquad;
    }

    private void OnDestroy()
    {
        EnemySpawner.OnLastWave -= OnLastWave;
        EnemySpawner.OnSpawnEnemySquad -= OnSpawnEnemy;
        HouseAI.OnDestroyHouse -= OnDestroyHouse;
        Squad.OnDeadSquad -= OnDeadSquad;
    }

    private void OnDeadSquad(string tag)
    {
        if (tag == "Player")
        {
            _countPlayerSquad--;
        }
        if (tag == "Enemy")
        {
            _countEnemySquad--;
        }

        if (_countPlayerSquad <= 0)
        {
            _losePanel.SetActive(true);
        }
        if (_canWin && _countEnemySquad <= 0)
        {
            _winPanel.SetActive(true);
        }
    }

    private void OnDestroyHouse()
    {
        _countHouse--;
        if (_countHouse <= 0)
        {
            _losePanel.SetActive(true);
        }
    }

    private void OnSpawnEnemy()
    {
        _countEnemySquad++;
    }

    private void OnLastWave()
    {
        _canWin = true;
    }
}
