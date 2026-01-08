using System.Collections;
using UnityEngine;

public class EnemySpawnerHandler : MonoBehaviour
{
    [SerializeField] WaveConfigSO[] waveConfigs;
    [SerializeField] float timeBetweenWaves = 1f;
    WaveConfigSO currentWave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemies());    
    }

    IEnumerator SpawnEnemies()
    {
        foreach(WaveConfigSO wave in waveConfigs)
        {
            currentWave = wave;
            for(int i = 0; i < currentWave.GetEnemyCount(); i++)
            {
                GameObject enemy = Instantiate(
                    currentWave.GetEnemyPrefab(i), 
                    currentWave.GetStartingWayPoint().position, 
                    Quaternion.identity,
                    transform);

                enemy.GetComponent<PathFinding>().SetWaveConfig(currentWave);

                yield return new WaitForSeconds(currentWave.GetRandomEnemySpawnTime());
            }
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
