using UnityEngine;

public class PathFinding : MonoBehaviour
{
    EnemySpawnerHandler enemySpawner;
    WaveConfigSO waveConfig;
    Transform[] waypoints;

    int waypointIndex = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemySpawner = FindFirstObjectByType<EnemySpawnerHandler>();
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWayPoints();
        transform.position = waveConfig.GetStartingWayPoint().position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if(waypointIndex < waypoints.Length)
        {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float moveDelta = waveConfig.GetEnemyMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveDelta);

            if(transform.position == targetPosition)
            {
                waypointIndex ++;
            }
        } 
        else
        {
            Destroy(gameObject);
        }
    }
}
