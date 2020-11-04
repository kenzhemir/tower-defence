using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        WaypointFollower waypointFollower = collision.gameObject.GetComponent<WaypointFollower>();
        if (waypointFollower != null){
            Destroy(collision.gameObject);
            Events.RemoveLives(waypointFollower.EnemyData.Damage);
        }
    }

}
