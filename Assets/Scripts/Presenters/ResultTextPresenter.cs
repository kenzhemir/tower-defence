using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultTextPresenter : MonoBehaviour
{
    public TextMeshProUGUI ResultTextComponent;
    public Button BackButton;

    private void Awake()
    {
        Events.OnEndLevel += OnEndLevel;
        gameObject.SetActive(false);
        BackButton.onClick.AddListener(BackToMenu);
    }

    private void OnDestroy()
    {
        Events.OnEndLevel -= OnEndLevel;
    }

    private void OnEndLevel(bool isWin)
    {
        gameObject.SetActive(true);
        if (isWin)
        {
            ResultTextComponent.text = "You Won!";
        } else
        {
            ResultTextComponent.text = "You lost!";
        }
    }

    private void BackToMenu()
    {
        MenuPresenter.Instance?.gameObject.SetActive(true);
        SceneManager.LoadScene("MenuScene");
    }
}
