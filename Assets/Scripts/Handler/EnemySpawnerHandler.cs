using System.Collections;
using UnityEngine;

public class EnemySpawnerHandler : MonoBehaviour
{
    [SerializeField] WaveConfigSO[] waveConfigs;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] bool isLooping;
    WaveConfigSO currentWave;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemies());    
    }

    IEnumerator SpawnEnemies()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while(isLooping);
    }

    IEnumerator SpawnAllWaves()
    {
            foreach(WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                yield return StartCoroutine( SpawningSingleWaves(wave) );
                yield return new WaitForSeconds(timeBetweenWaves);
            }
    }

    IEnumerator SpawningSingleWaves(WaveConfigSO wave)
    {
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
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
