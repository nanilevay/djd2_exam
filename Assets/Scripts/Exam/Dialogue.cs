using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject panel;

    public GameObject picture;

    public GameObject name;

    public TextMeshProUGUI textDisplay;

    public string[] introSentences;

    public string[] zenRoomSentences;

    public string[] storageSentences;

    public string [] sentences;

    public int index = 0;

    public float TypingSpeed;

    public bool intro = true;

    public bool zen = false;

    public bool storage = false;

    void Start()
    {
    
        sentences = introSentences;
        
        StartCoroutine(Type());

    }

    void Update()
    {  
        name.SetActive(true);
        picture.SetActive(true);


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
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }

        else
        {
            panel.SetActive(false);          
        }
    }

    public void ChangeTexts()
    {
        if(zen)
        {
            panel.SetActive(true);
            sentences = zenRoomSentences;
            index = 0;
            textDisplay.text = "";
            zen = false;
        }

        if (storage)
        {
            panel.SetActive(true);
            sentences = storageSentences;
            index = 0;
            textDisplay.text = "";
            storage = false;
        }
        
        /*
        else
        {  
            textDisplay.text = "I'm sleepy.....";         
        }
        */
    }
}
