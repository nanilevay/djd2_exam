using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteHandler : MonoBehaviour
{
    public GameObject panel;

    public TextMeshProUGUI textDisplay;

    public List<string> introSentences;

    public List<string> zenSentences;

    public List<string> karenSentences;

    public List<string> pabloSentences;

    public List<string> elmoSentences;

    public List<string> storageSentences;

    public string sentences;

    public int index = 0;

    public float TypingSpeed;

    public bool intro = true;

    public bool zen = true;

    public bool karen = false;

    public bool pablo = false;

    public bool elmo = false;

    void Start()
    {
        sentences = "Lock's notes:";

        foreach(string sentence in introSentences)
            sentences += sentence;

        textDisplay.text = sentences;   

    }

    void Update()
    {

      

        if (Input.GetKeyDown(KeyCode.Return))
        {
            ChangeTexts();
        }

    }

    public void ChangeTexts()
    {
        if (zen)
        {
            panel.SetActive(true);
            foreach (string sentence in zenSentences)
                sentences += sentence;
            textDisplay.text = sentences;
            zen = false;
        }

        if (karen)
        {
            panel.SetActive(true);
            //sentences += zenSentences;
            index = -1;
            textDisplay.text = "";
            karen = false;
        }

    }
}
