using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/TowerData")]
public class TowerData : ScriptableObject
{
    public string Name;
    public int Cost;
    public float ShootingDelay;
    public string Shortcut;
    public Sprite TopIcon;
    public Sprite BottomIcon;
    public Tower TowerPrefab;
    public Bullet BulletPrefab;
}
