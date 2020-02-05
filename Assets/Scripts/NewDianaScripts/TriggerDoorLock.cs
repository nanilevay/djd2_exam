using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorLock : MonoBehaviour
{
    public GameObject Door;

    public Dialogue monologue;

    public ViewController vc;

    void OnTriggerEnter()
    {
        Door.GetComponent<Animator>().SetBool("DoorOpen", false);

        vc.Final = true;

        monologue.final = true;

      Destroy(this);
    }
}
