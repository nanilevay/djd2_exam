using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public Inventory inventory;

    public GameObject Hand;

    public GameObject GoItem;

    private bool RotActive;

    public ViewController vc;

    public HUB hub;

    public GameObject ElmoMonologueTrigger;

    public GameObject Karen;

    public GameObject KarenAfterDeath;

    public GameObject Elmo;

    public GameObject ElmoAlive;

    public GameObject Broom;

    public GameObject DoorStorage;

    public GameObject DoorZen;

    public GameObject DoorLivingRoom;

    public GameObject zenSpeech;

    public GameObject pabloSpeech;

    public GameObject karenSpeech;

    public TriggerDoorLock trigger;

    public int clueCounter = 0;

    public int count = 0;

    private IInventoryItem mCurrentItem = null;

    public Dialogue innerMonologue;


    //
    public Dialogue zenDialogue;

    public Dialogue pabloDialogue;

    public Dialogue karenDialogue;

    public GameObject elmoDialogue;

    //

    public bool doorClosed;
    public bool doorOpen;
    public bool broomFall;

    private GameObject[] cluesList;

    private void Start()
    {
        
        inventory.ItemUsed += Inventory_ItemUsed;
        RotActive = true;

        cluesList = GameObject.FindGameObjectsWithTag("FootPrints");
    }

    public void Activate(bool rotActive)
    {
        GoItem.SetActive(false);
        RotActive = true;
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
            if(goItem.GetComponent<RotateObject>() != null)
                goItem.GetComponent<RotateObject>().enabled = true;
            goItem.transform.parent = Hand.transform;
            goItem.transform.localPosition = 
                (item as InventoryItemBase).PickPosition;
            goItem.transform.localEulerAngles = 
                (item as InventoryItemBase).PickRotation;

            GoItem = goItem;
        }

        GoItem = goItem;

    }

    
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(vc.InventoryIsActive == true)
            hub.OpenMessagePanel("");
    }
    
    void OnTriggerExit(Collider other)
    { 
        hub.CloseMessagePanel();
    }

    // Start is called before the first frame update
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Elmo")
        {
            hub.OpenMessagePanel("Press F to talk");

            if (Input.GetKeyDown(KeyCode.F))
            {
                hub.CloseMessagePanel();
                elmoDialogue.SetActive(true);
                count += 1;
            }
        }

        if (other.tag == "Karen1")
        {
            hub.OpenMessagePanel("Press F to talk");

            if (Input.GetKeyDown(KeyCode.F))
            {
                hub.CloseMessagePanel();
                karenSpeech.SetActive(true);
                count += 1;
            }
        }

        if (other.tag == "Karen2")
        {
            hub.OpenMessagePanel("Press F to talk");

            if (Input.GetKeyDown(KeyCode.F))
            {
                hub.CloseMessagePanel();
                karenSpeech.SetActive(true);
                karenDialogue.zen = true;
            }

        }

        if (other.tag == "Zen1")
        {
            hub.OpenMessagePanel("Press F to talk");

            if (Input.GetKeyDown(KeyCode.F))
            {
                hub.CloseMessagePanel();
                zenSpeech.SetActive(true);
                count += 1;
            }
        }

        if (other.tag == "Zen2")
        {
            hub.OpenMessagePanel("Press F to talk");

            if (Input.GetKeyDown(KeyCode.F))
            {
                hub.CloseMessagePanel();
                zenSpeech.SetActive(true);
                zenDialogue.zen = true;
                clueCounter += 1;
            }
            
        }

        if (other.tag == "Pablo1")
        {
            hub.OpenMessagePanel("Press F to talk");

            if (Input.GetKeyDown(KeyCode.F))
            {
                hub.CloseMessagePanel();
                pabloSpeech.SetActive(true);
                count += 1;
            }
        }

        if (other.tag == "Pablo2")
        {
            hub.OpenMessagePanel("Press F to talk");

            if (Input.GetKeyDown(KeyCode.F))
            {
                hub.CloseMessagePanel();
                pabloSpeech.SetActive(true);
                pabloDialogue.zen = true;
                clueCounter += 1;
            }

        }


        if (other.tag == "FootPrints")
        {
            hub.OpenMessagePanel("Examine Clue");

            if (Input.GetKeyDown(KeyCode.F))
            {
                hub.CloseMessagePanel();
                innerMonologue.clues = true;
                clueCounter += 1;

                foreach(GameObject clueprint in cluesList)
                    clueprint.GetComponent<BoxCollider>().enabled = false;
            }
        }

        IInventoryItem item = other.GetComponent<IInventoryItem>();

        IInventoryItem currentItem = null;
        

        if (item != null && other.tag == "Door")
        {
            hub.OpenMessagePanel("Press F to open door");

            if (Input.GetKeyDown(KeyCode.F))
            {
                item.OnUse();
                other.GetComponent<BoxCollider>().enabled = false;
                hub.CloseMessagePanel();
            }
        }

        if (item != null && other.tag == "LivingRoomDoor")
        {
            
            if (count >= 4)
            {
                hub.OpenMessagePanel("Press f to open");

                if (Input.GetKeyDown(KeyCode.F))
                {

                    item.OnUse();
                    other.GetComponent<BoxCollider>().enabled = false;
                    hub.CloseMessagePanel();
                }
            }

            else
                hub.OpenMessagePanel("Speak to your friends first!!");
            
            

        }


        if (item != null && other.tag == "ZamazonKit")
        {
            hub.OpenMessagePanel("Press F to obtain Zamazon Kit!!");
           
            trigger.GetComponent<BoxCollider>().enabled = true;
            doorClosed = true;

            if (Input.GetKeyDown(KeyCode.F))
            {
                hub.CloseMessagePanel();
                vc.ToggleKit(false);
                vc.InventoryIsActive = true;
                Destroy(other.gameObject);
                GameObject.FindWithTag("Zen1").tag = "Zen2";
                GameObject.FindWithTag("Pablo1").tag = "Pablo2";
                GameObject.FindWithTag("Karen1").tag = "Karen2";
                ElmoMonologueTrigger.SetActive(true);
                innerMonologue.zen = true;
                Destroy(ElmoAlive);
                Destroy(Karen);
                Instantiate(Elmo);
                Instantiate(KarenAfterDeath);
            }
        }

        if (vc.InventoryIsActive == true) 
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

            if (item != null && other.tag == "Clues")
            {
                hub.OpenMessagePanel("Press f to inspect clue");
                if (Input.GetKeyDown(KeyCode.F))
                {
                    item.OnUse();
                }
            }

            if (item != null && other.tag == "Exit")
            {
                hub.OpenMessagePanel("Press F to open door");

                if (Input.GetKeyDown(KeyCode.F))
                {
                    innerMonologue.storage = true;
                }
            }

            if (item != null && other.tag == "PictureClues")
            {

                hub.OpenMessagePanel("Press F to pick up");

                if (Input.GetKeyDown(KeyCode.F))
                {
                    inventory.AddItem(item);
                    item.OnPickup();

                    GameObject iitem = GameObject.Find(item.Name);
                    iitem.GetComponent<SpriteRenderer>().enabled=true;
                 
                    Destroy(other);
     
                    hub.OpenMessagePanel("");
                }
            }

            if(clueCounter >= 2)
            {
                DoorLivingRoom.GetComponent<Animator>().SetBool("DoorOpen", true);
                doorOpen = true;
            }

        }

    }
}
