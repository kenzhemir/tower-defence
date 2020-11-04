using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class TowerCardPresenter : MonoBehaviour
{
    public TowerData TowerData;

    public TextMeshProUGUI CostText;
    public TextMeshProUGUI ShortcutText;
    public Image TopImage;
    public Image BottomImage;

    private Button button;

    private void Awake()
    {
        Events.OnSetGold += OnSetGold;
        button = GetComponent<Button>();
    }

    private void Start()
    {
        if (button != null)
        {
            button.onClick.AddListener(Pressed);
        }

        if (TowerData != null)
        {
            CostText.text = TowerData.Cost.ToString();
            ShortcutText.text = TowerData.Shortcut;
            TopImage.sprite = TowerData.TopIcon;
            BottomImage.sprite = TowerData.BottomIcon;
        }
    }

    private void OnDestroy()
    {
        Events.OnSetGold -= OnSetGold;
    }

    private void OnSetGold(int gold)
    {
        if (gold < TowerData.Cost)
        {
            button.interactable = false;
        } else
        {
            button.interactable = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown((KeyCode)Enum.Parse(typeof(KeyCode), TowerData.Shortcut)))
        {
            if (button.interactable)
            {
                button.onClick.Invoke();
            }
        }
    }
    public void Pressed()
    {
        Events.SelectTower(TowerData);
    }

}
