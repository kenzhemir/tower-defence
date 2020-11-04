using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesPresenter : MonoBehaviour
{
    TextMeshProUGUI textMeshProUGUI;

    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        Events.OnSetLives += OnSetLives;
    }

    private void OnDestroy()
    {
        Events.OnSetLives -= OnSetLives;
    }
    private void OnSetLives(int lives) => textMeshProUGUI.text = "Lives: " + Mathf.Clamp(lives, 0, 1000);
}
