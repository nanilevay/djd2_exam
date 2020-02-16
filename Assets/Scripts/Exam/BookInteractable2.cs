using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookInteractable2 : InventoryItemBase
{
    private GameObject view;

    private ViewController viewScript;

    public GameObject panel;

    public GameObject[] pages;


    // this is a test of a specific item
    public override string Name
    {
        get
        {
            return "book2";
        }
    }

    public override string Description
    {
        get
        {
            return "Zen's Real Diary? What the hell is going on?";
        }
    }

    public override void OnUse()
    {
        viewScript.ToggleBookPanel2(false);
    }

    void Start()
    {

        view = GameObject.FindGameObjectWithTag("viewManager");
        viewScript = view.GetComponent<ViewController>();

    }

    public void NextPage(int current)
    {
        pages[current].SetActive(false);
        pages[current + 1].SetActive(true);
    }

    public void PreviousPage(int current)
    {
        pages[current].SetActive(false);
        pages[current + -1].SetActive(true);
    }
}
