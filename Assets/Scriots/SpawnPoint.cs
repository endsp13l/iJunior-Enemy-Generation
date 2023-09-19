using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private int _spawnDirectionInDegrees = 45;

    public void Spawn(GameObject template)
    {
        Quaternion spawnDirection = Quaternion.Euler(0, _spawnDirectionInDegrees, 0);
        Instantiate(template, transform.position, spawnDirection);
    }
}