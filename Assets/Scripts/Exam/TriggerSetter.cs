using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSetter : MonoBehaviour
{
    public Dialogue InnerMonologue;

    void OnTriggerEnter()
    {
        if(this.name == "ElmoSpeech")
            InnerMonologue.bloodMessage = true;

        if (this.name == "KitSpeech")
            InnerMonologue.kitSpeech = true;

        if (this.name == "Mirror")
        {
            InnerMonologue.zenMirror = true;
            this.GetComponent<Animator>().SetBool("MirrorOpen", true);
        }

        if (this.name == "LivingRoomStartTrigger")
        {
            InnerMonologue.investigationStart = true;
        }

        Destroy(this);
    }

    
}
