using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    private ScenarioData currentScenario;
    public WaypointFollower FollowerPrefab;
    public float TimeBetweenWaves = 2f;

    private float NextSpawnTime = 0;
    private int SpawnCount;
    private int currentWave = 0;

    private Waypoint waypoint;
    private HashSet<WaypointFollower> enemies;

    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
        enemies = new HashSet<WaypointFollower>();
        Events.OnWaypointFollowerDestroyed += OnWaypointFollowerDestroyed;
        Events.OnStartLevel += OnStartLevel;
        gameObject.SetActive(false);
    }

    private void OnStartLevel(ScenarioData scenario)
    {
        currentScenario = scenario;
        gameObject.SetActive(true);
    }

    private void OnDestroy()
    {
        Events.OnWaypointFollowerDestroyed -= OnWaypointFollowerDestroyed;
        Events.OnStartLevel -= OnStartLevel;
    }

    private void OnWaypointFollowerDestroyed(WaypointFollower obj)
    {
        enemies.Remove(obj);
    }

    private void Start()
    {
        SpawnCount = 0;
        Events.RegisterLevelSpawner(this);
    }

    private void Update()
    {
        if (SpawnCount < currentScenario.Waves[currentWave].NumberOfEnemies)
        {
            if (Time.time >= NextSpawnTime) SpawnEnemy();
        } else
        {
            if (currentWave < currentScenario.Waves.Length - 1)
            {
                StartNewWave();
            } else
            {
                if (enemies.Count <= 0 && gameObject.activeSelf)
                {
                    Events.UnregisterLevelSpawner(this);
                    gameObject.SetActive(false);
                }
            }
        }
    }   

    private void SpawnEnemy()
    {
        WaveData wave = currentScenario.Waves[currentWave];
        SpawnCount++;
        NextSpawnTime = Time.time + wave.CooldownBetweenEnemies;
        WaypointFollower enemy = Instantiate(FollowerPrefab, transform.position, Quaternion.identity, null);
        enemy.GetComponent<SpriteRenderer>().sprite = wave.EnemyType.Sprite;
        enemy.EnemyData = wave.EnemyType;
        enemy.GetComponent<Health>().EnemyData = wave.EnemyType;
        enemy.TargetWaypoint = waypoint;
        enemies.Add(enemy);
    }

    private void StartNewWave()
    {
        currentWave++;
        NextSpawnTime = Time.time + TimeBetweenWaves;
        SpawnCount = 0;
    }
}
