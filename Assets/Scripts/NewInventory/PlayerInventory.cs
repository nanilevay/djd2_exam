﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    // public GameObject karenSpeech;

    public Inventory inventory;

    public GameObject Hand;

    public GameObject GoItem;

    private bool RotActive;

    public ViewController vc;

    public HUB hub;

    public GameObject Elmo;

    public GameObject Broom;

    public GameObject DoorStorage;

    public GameObject DoorZen;

    public GameObject DoorLivingRoom;

    public TriggerDoorLock trigger;

    public int counter = 0;

    private IInventoryItem mCurrentItem = null;
   
    public bool doorClosed;
    public bool doorOpen;
    public bool broomFall;
    public bool s_1;
    public bool s_2;

    private void Start()
    {
        inventory.ItemUsed += Inventory_ItemUsed;
        RotActive = true;
        s_1 = true;
    }

    public void Activate(bool rotActive)
    {
        RotActive= rotActive;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R) || !RotActive && GoItem != null)
        {
            GoItem.SetActive(false);

            GoItem.GetComponent<RotateObject>().enabled = true;

            RotActive = true;
        }
    }

    private void Inventory_ItemUsed(object sender, InventoryEventArgs e)
    {
        IInventoryItem item = e.Item;

        GameObject goItem;

        if (item.Name == "passwordReader")
        {
            goItem = (item as MonoBehaviour).gameObject;

            item.OnUse();
            goItem = null;
        }

        if (item.Name == "book")
        {
            goItem = (item as MonoBehaviour).gameObject;

            vc.ToggleInventory(true);
            GoItem = goItem;
            Broom.GetComponent<Animator>().SetBool("Fall", true);
            DoorStorage.GetComponent<Animator>().SetBool("DoorOpen", true);
            broomFall = true;

            //FindOjbectOfType<AudioSource>().Play("Fallingbroom");
        }

        else
        {
            goItem = (item as MonoBehaviour).gameObject;

            goItem.SetActive(true);
            goItem.GetComponent<RotateObject>().enabled = true;
            goItem.transform.parent = Hand.transform;
            goItem.transform.localPosition = (item as InventoryItemBase).PickPosition;
            goItem.transform.localEulerAngles = (item as InventoryItemBase).PickRotation;

            GoItem = goItem;
        }

        GoItem = goItem;

    }

    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(vc.InventoryIsActive == true)
            hub.OpenMessagePanel("");
        /*
        if (other.tag == "Karen")
        {
            //gameObject.GetComponent<CharacterController>().enabled = false;
            gameObject.GetComponent<PlayerMov>().enabled = false;
            karenSpeech.SetActive(true);
        }
        */
    }
    
    void OnTriggerExit(Collider other)
    { 
        hub.CloseMessagePanel();
    }

    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        IInventoryItem item = other.GetComponent<IInventoryItem>();

        IInventoryItem currentItem = null;

        if (item != null && other.tag == "ZamazonKit")
        {
            hub.OpenMessagePanel("Press F to obtain Zamazon Kit!!");
            trigger.GetComponent<BoxCollider>().enabled = true;
            doorClosed = true;
            if (Input.GetKeyDown(KeyCode.F))
            {
                vc.ToggleKit(false);
                vc.InventoryIsActive = true;
                Instantiate(Elmo);
                s_1 = false;
                s_2 = true;
            }
        }

        if(vc.InventoryIsActive == true) 
        { 
            if (item != null && other.tag == "Pickable")
            {
                hub.OpenMessagePanel("Press F to pick up");
            
                if (Input.GetKeyDown(KeyCode.F))
                {
                    inventory.AddItem(item);
                    item.OnPickup();
                }
            }

            if (item != null && other.tag == "Touchable")
            {
                hub.OpenMessagePanel("Press f to use");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    item.OnUse();
                }
            }

          

            if (item != null && other.tag == "PictureClues")
            {
                counter+=1;

                hub.OpenMessagePanel("Press F to pick up");

                if (Input.GetKeyDown(KeyCode.F))
                {
                    inventory.AddItem(item);
                    item.OnPickup();

                    GameObject iitem = GameObject.Find(item.Name);
                    iitem.GetComponent<SpriteRenderer>().enabled=true;
                 
                    Destroy(other);
     
                    hub.OpenMessagePanel("");

                    Debug.Log(counter);
                }
            }

            if(counter >= 4)
            {
                DoorLivingRoom.GetComponent<Animator>().SetBool("DoorOpen", true);
                doorOpen = true;
            }

        }

    }
}