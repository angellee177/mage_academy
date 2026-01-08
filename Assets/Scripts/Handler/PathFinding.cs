using UnityEngine;

public class PathFinding : MonoBehaviour
{
    WaveConfigSO waveConfig;
    Transform[] waypoints;

    int waypointIndex = 0;

    public void SetWaveConfig(WaveConfigSO config)
    {
        this.waveConfig = config;
        waypoints = waveConfig.GetWayPoints();
        transform.position = waveConfig.GetStartingWayPoint().position;
    }

    // Update is called once per frame
    void Update()
    {
        if(waveConfig != null)
        {
            FollowPath();
        }
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
