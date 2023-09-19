using System.Collections;
using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 2f;
    [SerializeField] private GameObject _enemyPrefab;

    private SpawnPoint[] _spawnPoints = new SpawnPoint[0];
    private Random _random = new Random();

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        StartCoroutine(DelaySpawn());
    }

    private IEnumerator DelaySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTime);
            SpawnEnemy(GetRandomSpawnPoint());
        }
    }

    private SpawnPoint GetRandomSpawnPoint()
    {
        return _spawnPoints[_random.Next(_spawnPoints.Length)];
    }

    private void SpawnEnemy(SpawnPoint spawnPiont)
    {
        spawnPiont.Spawn(_enemyPrefab);
    }

    private void OnDisable()
    {
        StopCoroutine(DelaySpawn());
    }
}