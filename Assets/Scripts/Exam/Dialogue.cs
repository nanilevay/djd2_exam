using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject panel;

    public GameObject name;

    public TextMeshProUGUI textDisplay;

    public string[] introSentences;

    public string[] zenRoomSentences;

    public string[] storageSentences;

    public string[] bloodClueSentences;

    public string[] mirrorSentences;

    public string[] cluesSentences;

    public string [] sentences;

    public int index = 0;

    public float TypingSpeed;

    public bool intro = true;

    public bool zen = false;

    public bool zenMirror = false;

    public bool storage = false;

    public bool clues = false;

    public bool bloodMessage = false;

    private GameObject player;

    PlayerLook camera;

    void Start()
    {
        
        sentences = introSentences;
        player = GameObject.FindWithTag("Player");
        camera = GameObject.FindWithTag("MainCamera").GetComponent<PlayerLook>();

        if (player != null)
            player.GetComponent<CharacterController>().enabled = false;
        if (camera != null)
            camera.enabled = false;
        StartCoroutine(Type());

    }

    void Update()
    {  
        name.SetActive(true);
        
        ChangeTexts();


        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextSentence();
        }     

    }

    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;

            yield return new WaitForSeconds(TypingSpeed);
        }
    }

    public void NextSentence()
    {
        if(index < sentences.Length - 1)
        {
            if(player != null)
                player.GetComponent<CharacterController>().enabled = false;
            if (camera != null)
                camera.enabled = false;
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }

        else
        {
            panel.SetActive(false);

            if (player != null)
                player.GetComponent<CharacterController>().enabled = true;
            if (camera != null)
                camera.enabled = true;
        }
    }

    public void ChangeTexts()
    {
        if(zen)
        {
            panel.SetActive(true);
            sentences = zenRoomSentences;
            index = -1;
            textDisplay.text = "";
            zen = false;
        }

        if (bloodMessage)
        {
            panel.SetActive(true);
            sentences = bloodClueSentences;
            index = -1;
            textDisplay.text = "";
            bloodMessage = false;
        }

        if (zenMirror)
        {
            panel.SetActive(true);
            sentences = mirrorSentences;
            index = -1;
            textDisplay.text = "";
            zenMirror = false;
        }

        if (storage)
        {
            panel.SetActive(true);
            sentences = storageSentences;
            index = -1;
            textDisplay.text = "";
            storage = false;
        }

        if (clues)
        {
            panel.SetActive(true);
            sentences = cluesSentences;
            index = -1;
            textDisplay.text = "";
            clues = false;
        }

    }
}
