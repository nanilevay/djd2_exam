using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : InventoryItemBase
{
    private GameObject view;
    private ViewController viewScript;

    public GameObject Door;

    void Start()
    {
        view = GameObject.FindGameObjectWithTag("viewManager");
        viewScript = view.GetComponent<ViewController>();

    }

    // this is a test of a specific item
    public override string Name
    {
        get
        {
            return "Door";
        }
    }

    public override void OnUse()
    {
        this.GetComponent<Animator>().SetBool("open", true);
    }


}
