using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimations : MonoBehaviour
{
    public GameObject innerSpeech;

    public bool fading;

    public HUB hub;

    void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        gameObject.GetComponent<Animator>().SetBool("fading", true);       

        yield return new WaitForSeconds(2);

        if(innerSpeech != null)
            innerSpeech.SetActive(true);
    }
}