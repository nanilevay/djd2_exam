using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSetter1 : MonoBehaviour
{
    public Dialogue InnerMonologue;

    void OnTriggerEnter()
    {
        InnerMonologue.KarenSuspicion = true;

        Destroy(this);
    }

    
}
