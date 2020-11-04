using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TowerBuilder : MonoBehaviour
{
    public Color AllowColor;
    public Color BlockColor;
    public SpriteRenderer Top;
    public SpriteRenderer Bottom;

    private TowerData currentTowerData;

    private void Awake()
    {
        Events.OnTowerSelected += OnTowerSelected;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Events.OnTowerSelected -= OnTowerSelected;
    }

    private void OnTowerSelected(TowerData obj)
    {
        currentTowerData = obj;
        Top.sprite = obj.TopIcon;
        Bottom.sprite = obj.BottomIcon;
        gameObject.SetActive(true);
    }

    void Update()
    {
        //Reposition the gameobject to mouse coordinates. 
        //Round the coordinates to make it snap to a grid.

        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos = new Vector3(
            Mathf.Round(mousepos.x - 0.5f) + 0.5f, Mathf.Round(mousepos.y - 0.5f) + 0.5f, 0);

        transform.position = mousepos;

        //Verify that building area is free of other towers. 
        //By using a static overlap method from Physics2D class we can make this work without collider and a 2d rigidbody.

        if (isFree(transform.position) && isAffordable())
        {
            TintSprite(AllowColor);
        } else
        {
            TintSprite(BlockColor);
        }

        //Tint the sprite to green or red accordingly.
        //Call the build method when the player presses left mouse button

        if (Input.GetMouseButtonDown(1))
        {
            gameObject.SetActive(false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Build();
        }
    }

    void TintSprite (Color c)
    {
        foreach (SpriteRenderer spr in gameObject.GetComponentsInChildren<SpriteRenderer>())
        {
            spr.color = c;
        }

    }

    bool isFree(Vector3 pos)
    {
        Collider2D[] overlaps = Physics2D.OverlapCircleAll(pos, 0.45f);
        foreach (Collider2D overlap in overlaps)
        {
            if (!overlap.isTrigger)
            {
                return false;
            }
        }
        return true;
    }

    bool isAffordable()
    {
        return Events.GetGold() >= currentTowerData.Cost;
    }

    void Build()
    {
        if (!isFree(transform.position)) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (!isAffordable()) return;

        Events.RemoveGold(currentTowerData.Cost);
        Tower tower = GameObject.Instantiate(currentTowerData.TowerPrefab, transform.position, Quaternion.identity, null);
        tower.TowerData = currentTowerData;
        gameObject.SetActive(false);
    }
}
