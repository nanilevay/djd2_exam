using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueInteractive : InventoryItemBase
{
    private Dialogue Monologue;

    private PlayerInventory inventory;

    void Start()
    {
        Monologue = GameObject.Find("InnerMonologue").GetComponent<Dialogue>();
        inventory = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    // this is a test of a specific item
    public override string Name
    {
        get
        {
            return "clue";
        }
    }

    public override void OnUse()
    {
        Monologue.bloodMessageInspect = true;
        inventory.getPoison = true;
            this.GetComponent<BoxCollider>().enabled = false;
    }
}
