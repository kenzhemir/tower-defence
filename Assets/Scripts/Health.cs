using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public EnemyData EnemyData;
    public int currentHealth;
    public int CurrentHealth
    {
        get => currentHealth;
        set
        {
            if (value <= 0)
            {
                Kill();
            }
            else
            {
                currentHealth = value;
            }
        }
    }

    private void Start()
    {
        CurrentHealth = EnemyData.Health;
    }

    internal void Damage(int damage)
    {
        CurrentHealth -= damage;
    }

    private void Kill()
    {
        Events.AddGold(EnemyData.Reward);
        Destroy(gameObject);
    }
}
