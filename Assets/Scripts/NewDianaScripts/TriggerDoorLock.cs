using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorLock : MonoBehaviour
{
    public GameObject Door;

    public Dialogue monologue;

    void OnTriggerEnter()
    {
        Door.GetComponent<Animator>().SetBool("DoorOpen", false);

        monologue.final = true;

      Destroy(this);
    }
}
