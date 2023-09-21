using System.Collections;
using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _spawnDirectionInDegrees = 45;
    [SerializeField] private float _spawnTime = 2f;
    [SerializeField] private Enemy _enemyPrefab;

    private SpawnPoint[] _spawnPoints = new SpawnPoint[0];
    private Random _random = new Random();

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        StartCoroutine(DelaySpawn());
    }

    private IEnumerator DelaySpawn()
    {
        WaitForSeconds spawnDelay = new WaitForSeconds(_spawnTime);

        while (true)
        {
            yield return spawnDelay;
            SpawnEnemy(GetRandomSpawnPoint());
        }
    }

    private SpawnPoint GetRandomSpawnPoint()
    {
        return _spawnPoints[_random.Next(_spawnPoints.Length)];
    }

    private void SpawnEnemy(SpawnPoint spawnPiont)
    {
        Quaternion spawnDirection = Quaternion.Euler(0, _spawnDirectionInDegrees, 0);
        Instantiate(_enemyPrefab, spawnPiont.transform.position, spawnDirection);
    }

    private void OnDisable()
    {
        StopCoroutine(DelaySpawn());
    }
}