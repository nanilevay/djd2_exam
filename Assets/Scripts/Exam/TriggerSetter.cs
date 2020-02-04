using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSetter : MonoBehaviour
{
    public Dialogue InnerMonologue;

    void OnTriggerEnter()
    {
        InnerMonologue.zenMirror = true;

        Destroy(this);
    }
}
