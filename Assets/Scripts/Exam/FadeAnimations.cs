using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimations : MonoBehaviour
{
    public GameObject karenSpeech;
   
    public bool fading;

    public HUB hub;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        gameObject.GetComponent<Animator>().SetBool("fading", true);       

        yield return new WaitForSeconds(2);

        karenSpeech.SetActive(true);
    }
}