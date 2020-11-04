using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Events
{
    public static event Action<TowerData> OnTowerSelected;
    public static void SelectTower(TowerData data) => OnTowerSelected?.Invoke(data);
    public static event Func<int> OnGetGold;
    public static int GetGold() => OnGetGold?.Invoke() ?? 0;
    public static event Action<int> OnSetGold;
    public static void SetGold(int amount) => OnSetGold?.Invoke(amount);
    public static void AddGold(int amount) => OnSetGold?.Invoke(GetGold() + amount);
    public static void RemoveGold(int amount) => OnSetGold?.Invoke(GetGold() - amount);
    public static event Action<ScenarioData> OnStartLevel;
    public static void StartLevel(ScenarioData scenarioData) => OnStartLevel?.Invoke(scenarioData);
    public static event Action<bool> OnEndLevel;
    public static void WinLevel() => OnEndLevel?.Invoke(true);

    public static void LoseLevel() => OnEndLevel?.Invoke(false);

    public static event Func<int> OnGetLives;
    public static int GetLives() => OnGetLives?.Invoke() ?? 0;
    public static event Action<int> OnSetLives;
    public static void SetLives(int amount) => OnSetLives?.Invoke(amount);
    public static void AddLives(int amount) => OnSetLives?.Invoke(GetLives() + amount);
    public static void RemoveLives(int amount) => OnSetLives?.Invoke(GetLives() - amount);

    public static event Action<WaypointFollower> OnWaypointFollowerDestroyed;
    public static void WaypointFollowerDestroyed(WaypointFollower waypointFollower) => OnWaypointFollowerDestroyed?.Invoke(waypointFollower);
    public static event Action<Spawn> OnUnregisterSpawner;
    internal static void UnregisterLevelSpawner(Spawn spawn) => OnUnregisterSpawner?.Invoke(spawn);
    public static event Action<Spawn> OnRegisterSpawner;
    internal static void RegisterLevelSpawner(Spawn spawn) => OnRegisterSpawner?.Invoke(spawn);

    public static event Action OnRestart;
    internal static void Restart() => OnRestart?.Invoke();
}
