using System.Collections;
using UnityEngine;
using Random = System.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnTime = 2f;

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

    private void SpawnEnemy(SpawnPoint spawnPoint)
    {
        Enemy enemy = Instantiate(spawnPoint.Enemy, spawnPoint.transform.position, Quaternion.identity);
        enemy.SetTarget(spawnPoint.Target);
    }

    private void OnDisable()
    {
        StopCoroutine(DelaySpawn());
    }
}