using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPickable : InventoryItemBase
{
    public GameObject PabloPrint;
    // this is a test of a specific item
    public override string Name
    {
        get
        {
            return "test";
        }
    }

    // this is a test of a specific item
    public override string Description
    {
        get
        {
            return "What looks to be poison. Whoever killed Elmo must have" +
                "used this, but why does it have blood? Also... It was on the" +
                "microwave, for some reason.";
        }
    }

    public override void OnUse()
    {
        // ADD NOTES
    }

    public void ShowPaw(bool pawOn)
    {
        PabloPrint.SetActive(true);
    }
}
