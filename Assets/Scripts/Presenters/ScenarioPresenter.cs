using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ScenarioPresenter : MonoBehaviour
{
    public ScenarioData Scenario;
    public TextMeshProUGUI NameText;
    private Button button;


    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    public void AddData(ScenarioData scenario)
    {
        Scenario = scenario;
        NameText.text = Scenario.PresentedName;
    }

    private void onClick()
    {
        MenuPresenter.Instance.ScenarioSelected(Scenario);
    }
}
