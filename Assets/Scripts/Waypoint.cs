using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint[] PossibleNextPoints;

    public Waypoint GetNextWaypoint()
    {
        if (PossibleNextPoints == null || PossibleNextPoints.Length == 0) return null;
        int ind = Random.Range(0, PossibleNextPoints.Length);
        return PossibleNextPoints[ind];
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        foreach (Waypoint Next in PossibleNextPoints)
        {
            if (Next != null) Gizmos.DrawLine(transform.position, Next.transform.position);
        }
    }
}
