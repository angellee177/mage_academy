using UnityEngine;

public class EnemySpawnerHandler : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnEnemies();    
    }

    void SpawnEnemies()
    {
        for(int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(
                currentWave.GetEnemyPrefab(i), 
                currentWave.GetStartingWayPoint().position, 
                Quaternion.identity,
                transform
            );
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
