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

        if (this.name == "Mirror")
            InnerMonologue.zenMirror = true;

        Destroy(this);
    }
}
