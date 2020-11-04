using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TowerDefence/Scenario")]
public class ScenarioData : ScriptableObject
{
    public string PresentedName;
    public string SceneName;
    public int Lives = 10;
    public int StartingGold;

    public WaveData[] Waves;
    public TowerData[] Towers;
}
