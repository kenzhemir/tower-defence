using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenarioController : MonoBehaviour
{
    public int InitialGold;
    public int InitialLives;
    public ScenarioData DefaultScenario;

    private ScenarioData currentScenario;

    private int gold;
    private int lives;
    private HashSet<Spawn> spawners;

    private void Awake()
    {
        spawners = new HashSet<Spawn>();
        Events.OnSetGold += OnSetGold;
        Events.OnSetLives += OnSetLives;
        Events.OnGetGold += OnGetGold;
        Events.OnGetLives += OnGetLives;
        Events.OnEndLevel += OnEndLevel;
        Events.OnRegisterSpawner += OnRegisterSpawner;
        Events.OnUnregisterSpawner += OnUnregisterSpawner;
        Events.OnRestart += OnRestart;
        Events.OnStartLevel += OnStartLevel;
    }

    private void OnDestroy()
    {
        Events.OnSetGold -= OnSetGold;
        Events.OnSetLives -= OnSetLives;
        Events.OnGetGold -= OnGetGold;
        Events.OnGetLives -= OnGetLives;
        Events.OnEndLevel -= OnEndLevel;
        Events.OnRegisterSpawner -= OnRegisterSpawner;
        Events.OnUnregisterSpawner -= OnUnregisterSpawner;
        Events.OnRestart -= OnRestart;
        Events.OnStartLevel -= OnStartLevel;
    }

    private void Start()
    {
        if (currentScenario == null)
        {
            Events.StartLevel(DefaultScenario);
        }
    }

    private void OnRegisterSpawner(Spawn spawn) { 
        spawners.Add(spawn); 
    }

    private void OnUnregisterSpawner(Spawn spawn)
    {
        spawners.Remove(spawn);
        if (spawners.Count == 0)
        {
            Events.WinLevel();
        }
    }

    private void OnSetLives(int new_lives)
    {
        if (new_lives <= 0)
        {
            Events.LoseLevel();
        }
        else
        {
            lives = new_lives;
        }
    }

    private void OnEndLevel(bool isWin)
    {
        Debug.Log("Game ended, win = " + isWin);
        Time.timeScale = 0;
    }
    private void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    private void OnStartLevel(ScenarioData scenario)
    {
        currentScenario = scenario;
        Events.SetGold(currentScenario.StartingGold);
        Events.SetLives(currentScenario.Lives);
        Time.timeScale = 1;
    }


    private int OnGetGold() => gold;
    private int OnGetLives() => lives;
    private void OnSetGold(int value)
    {
        gold = value;
    }
}
