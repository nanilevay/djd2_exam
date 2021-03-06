﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemClickHandler : MonoBehaviour
{
    public Inventory _Inventory;

    public PlayerInventory pinv;

    public KeyCode _Key;

    private Button _button;

    public HUB hub;

    void Awake()
    { 
        _button = GetComponent<Button>();
    }

    void Update()
    {
        if(Input.GetKeyDown(_Key))
        {
            FadeToColour(_button.colors.pressedColor);

            _button.onClick.Invoke();

        }

        else if (Input.GetKeyUp(_Key))
        {
            FadeToColour(_button.colors.normalColor);
        }
    }

    void FadeToColour(Color colour)
    {
        Graphic graphic = GetComponent<Graphic>();

        graphic.CrossFadeColor(colour, _button.colors.fadeDuration, true, true);
    }

    private IInventoryItem AttachedItem

    {
        get
        {
            ItemDragHandler dragHandler = gameObject.transform.Find("ItemImage").GetComponent<ItemDragHandler>();

            return dragHandler.Item;
        }
    }

    public void OnItemClicked()
    {
        IInventoryItem item = AttachedItem;

        if(item != null)
        {
            pinv.GoItem = null;

            _Inventory.UseItem(item);

            //item.OnUse();

            hub.DescPanel.SetActive(true);
            hub.DescText.text = item.Description;

            foreach (GameObject button in (hub.interactionButtons))
                button.SetActive(true);
        }
    }
}
