using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldPresenter : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;
    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        Events.OnSetGold += OnSetGold;
    }

    private void OnDestroy()
    {
        Events.OnSetGold -= OnSetGold;
    }

    private void OnSetGold(int gold) => textMeshProUGUI.text = "Gold: " + gold;
}
