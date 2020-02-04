using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveInteractive : InventoryItemBase
{
    public HUB Hub;

    public PlayerInventory inventory;

    public GameObject poison;

    // this is a test of a specific item
    public override string Name
    {
        get
        {
            return "Microwave";
        }
    }

    public override void OnUse()
    {
        Hub.OpenMessagePanel("open microwave");
        inventory.clueCounter += 1;
        this.GetComponent<Animator>().SetBool("MicrowaveOpen",true);
        this.GetComponent<BoxCollider>().enabled = false;
        poison.SetActive(true);
    }
}
