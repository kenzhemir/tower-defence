using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public Waypoint TargetWaypoint;
    public float Speed = 2f;
    public float sum = 0;

    public EnemyData EnemyData;

    void Update()
    {
        if (TargetWaypoint == null) return;
        transform.position = Vector3.MoveTowards(transform.position, TargetWaypoint.transform.position, Time.deltaTime * EnemyData.MovementSpeed);
        sum += Time.deltaTime;
        float distance = Vector3.SqrMagnitude(transform.position - TargetWaypoint.transform.position);
        if (distance <= float.Epsilon)
        {
            TargetWaypoint = TargetWaypoint.GetNextWaypoint();
        }
    }

    private void OnDestroy()
    {
        Events.WaypointFollowerDestroyed(this);
    }
}
