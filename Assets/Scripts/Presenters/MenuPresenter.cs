using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuPresenter : MonoBehaviour
{
    public static MenuPresenter Instance;
    public Button ExitButton;
    public RectTransform Panel;

    public ScenarioPresenter ScenarioPresenterPrefab;

    [HideInInspector]
    public ScenarioData SelectedScenario;
    public List<ScenarioData> Scenarios;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        ExitButton.onClick.AddListener(OnExit);
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        foreach (ScenarioData scenario in Scenarios)
        {
            ScenarioPresenter presenter = Instantiate(ScenarioPresenterPrefab, Panel);
            presenter.AddData(scenario);
        }
    }

    public void ScenarioSelected(ScenarioData scenario)
    {
        SelectedScenario = scenario;
        SceneManager.LoadScene(scenario.SceneName);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 0) return;
        gameObject.SetActive(false);
        Events.StartLevel(SelectedScenario);
    }

    private void OnExit()
    {
        Application.Quit();
    }
}
