using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TowerDefence/Enemy")]
public class EnemyData : ScriptableObject
{
    public int Health = 1;
    public int Damage = 1;
    public float MovementSpeed = 2f;
    public int Reward = 1;
    public Sprite Sprite;
}

