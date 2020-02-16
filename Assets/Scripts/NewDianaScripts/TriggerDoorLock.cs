using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorLock : MonoBehaviour
{
    public GameObject Door;

    public Dialogue monologue;

    public ViewController vc;

    public NoteHandler notes;

    void OnTriggerEnter()
    {
       
        Door.GetComponent<Animator>().SetBool("DoorOpen", false);

        //vc.Final = true;

        notes.noteTaking = true;
        notes.AddTextLock(4);
        notes.noteTaking = false;

        //monologue.final = true;

        Destroy(this);
    }
}
