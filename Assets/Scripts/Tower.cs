using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    public TowerData TowerData;

    private Base basepoint;
    private List<Health> EnemiesInRange;
    private float NextBulletTime;

    private void Awake()
    {
        EnemiesInRange = new List<Health>();
        basepoint = FindObjectOfType<Base>();
    }

    private void Update()
    {
        if (Time.time > NextBulletTime && EnemiesInRange.Count > 0)
        {
            Fire();
        }
    }

    private void Fire()
    {
        NextBulletTime = Time.time + TowerData.ShootingDelay;
        Bullet b = Instantiate(TowerData.BulletPrefab, transform.position, Quaternion.identity, null);
        Health closest = null;
        float minVal = float.MaxValue;
        EnemiesInRange = EnemiesInRange.FindAll(e => e != null);
        EnemiesInRange.ForEach((enemy) =>
        {
            float val = (basepoint.transform.position - enemy.transform.position).sqrMagnitude;
            if (val < minVal)
                {
                    closest = enemy;
                    minVal = val;
                }
        });
        b.Target = closest;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health enemy = collision.GetComponent<Health>();
        if (enemy != null)
        {
            EnemiesInRange.Add(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Health enemy = collision.GetComponent<Health>();
        if (enemy != null)
        {
            EnemiesInRange.Remove(enemy);
        }
    }
}
