using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _target;

    public Transform Target => _target;
    public Enemy Enemy => _enemyPrefab;
}