using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelRowPresenter : MonoBehaviour
{
    public TowerCardPresenter TowerCardPresenterPrefab;
    public ScenarioData Scenario;

    private void Awake()
    {
        Events.OnStartLevel += OnStartLevel;
    }

    private void OnDestroy()
    {
        Events.OnStartLevel -= OnStartLevel;
    }

    private void OnStartLevel(ScenarioData obj)
    {
        Scenario = obj;
        for (int i = transform.childCount-1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i));
        }

        foreach (TowerData tower in Scenario.Towers)
        {
            TowerCardPresenter presenter = Instantiate(TowerCardPresenterPrefab, transform);
            presenter.TowerData = tower;

        }
    }
}
