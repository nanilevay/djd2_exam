using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ViewController : MonoBehaviour
{
    public GameObject inventory;
    public GameObject player;
    public GameObject pauseMenu;
    public GameObject inputMenu;
    public GameObject bookPanel;
    public GameObject bookPanel2;
    public GameObject notesPanel;
    public GameObject zamazonKitPanel;
    public GameObject suspectPanel;

    public GameObject DescPanel;
    public TextMeshProUGUI DescText;

    public GameObject ChickenTrail;

    public bool InputChecking;
    public bool passwordCorrect;

    public bool InventoryIsActive = false;

    public bool Final = false;

    void Start()
    {
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        InputChecking = false;
        passwordCorrect = false;
    }

    void Update()
    {
        if(!InputChecking)
            CheckInput();
    }

    public void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.I) && InventoryIsActive == true)
        {
            
            ToggleInventory(false);
            ShowMouseCursor();     
        }

        if (Input.GetKeyDown(KeyCode.L) && InventoryIsActive == true)
        {

            ChickenTrail.SetActive(!ChickenTrail.activeInHierarchy);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePauseMenu(false);
            ShowMouseCursor();
        }

        if (Input.GetKeyDown(KeyCode.C) && Final)
        {
            ToggleSuspects(false);
            ShowMouseCursor();
        }

        
        if (Input.GetKeyDown(KeyCode.N) && InventoryIsActive == true)
        {
            ToggleNotes(false);
            ShowMouseCursor();
        }
        

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ToggleKit(false);
            ShowMouseCursor();
        }
    }

    public void ToggleKit(bool condition)
    {
        InputChecking = !zamazonKitPanel.activeInHierarchy;
        zamazonKitPanel.SetActive(!zamazonKitPanel.activeInHierarchy);
        StopPlayerMotion(!zamazonKitPanel.activeInHierarchy);
    }

    public void ToggleInputPanel(bool condition)
    {
        InputChecking = !inputMenu.activeInHierarchy;
        inputMenu.SetActive(!inputMenu.activeInHierarchy);
        StopPlayerMotion(!inputMenu.activeInHierarchy);
    }

    public void ToggleBookPanel(bool condition)
    {
        InputChecking = !bookPanel.activeInHierarchy;
        bookPanel.SetActive(!bookPanel.activeInHierarchy);
        StopPlayerMotion(!bookPanel.activeInHierarchy);
    }

    public void ToggleBookPanel2(bool condition)
    {
        InputChecking = !bookPanel2.activeInHierarchy;
        bookPanel2.SetActive(!bookPanel2.activeInHierarchy);
        StopPlayerMotion(!bookPanel2.activeInHierarchy);
    }


    public void TogglePauseMenu(bool condition)
    {
        InputChecking = !pauseMenu.activeInHierarchy;
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);
        StopPlayerMotion(!pauseMenu.activeInHierarchy);
    }

    public void ToggleSuspects(bool condition)
    {
        InputChecking = !suspectPanel.activeInHierarchy;
        suspectPanel.SetActive(!suspectPanel.activeInHierarchy);
        StopPlayerMotion(!suspectPanel.activeInHierarchy);
    }

    public void ToggleNotes(bool condition)
    {
        InputChecking = !notesPanel.activeInHierarchy;
        notesPanel.SetActive(!notesPanel.activeInHierarchy);
        StopPlayerMotion(!notesPanel.activeInHierarchy);
    }

    public void ToggleInventory(bool condition)
    {
        InputChecking = !inventory.activeInHierarchy;
        inventory.SetActive(!inventory.activeInHierarchy);
        StopPlayerMotion(!inventory.activeInHierarchy);
        DescPanel.SetActive(inventory.activeInHierarchy);
        if (!condition)
            DescText.text = "";
    }
    
    public void StopPlayerMotion(bool condition)
    {
        if (!condition)
        {
            Time.timeScale = 0;
            ShowMouseCursor();
        }

        else
        {
            Time.timeScale = 1.0f;
            HideMouseCursor();
        }
    }

    public void ShowMouseCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Screen.lockCursor = false;
    }

    public void HideMouseCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        Screen.lockCursor = true;
    }
}
