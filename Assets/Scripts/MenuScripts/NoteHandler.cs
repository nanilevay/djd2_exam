using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NoteHandler : MonoBehaviour
{
    public GameObject panel;

    public GameObject[] pages;

    public TextMeshProUGUI LockText;

    public TextMeshProUGUI ZenText;

    public TextMeshProUGUI KarenText;

    public TextMeshProUGUI PabloText;

    public TextMeshProUGUI ElmoText;

    public List<string> introSentences;

    public List<string> zenSentences;

    public List<string> karenSentences;

    public List<string> pabloSentences;

    public List<string> elmoSentences;

    public string sentences;

    public int index = 0;

    int count;

    public float TypingSpeed;

    public bool intro = true;

    public bool zen = true;

    public bool karen = false;

    public bool pablo = false;

    public bool elmo = false;

    void Start()
    {
        /*
        sentences = "";

        zenSentences = "";

        karenSentences = "";

        pabloSentences = "";

        elmoSentences = "";
        */

        foreach (string sentence in introSentences)
            sentences += sentence;

        LockText.text = "";

        ZenText.text = "";

        KarenText.text = "";

        PabloText.text = "";

        ElmoText.text = "";

        count = 0;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //ChangeTexts();
            
            AddTextLock(count);
            AddTextZen(count);
            AddTextElmo(count);
            AddTextKaren(count);
            AddTextPablo(count);
            count += 1;
        }
    }

    public void NextPage(int current)
    {
        pages[current].SetActive(false);
        pages[current+1].SetActive(true);
    }

    public void PreviousPage(int current)
    {
        pages[current].SetActive(false);
        pages[current + -1].SetActive(true);
    }

    public void AddTextLock(int index)
    {
        LockText.text += introSentences[index];
    }

    public void AddTextZen(int index)
    {
        ZenText.text += zenSentences[index];
    }

    public void AddTextPablo(int index)
    {
        PabloText.text += pabloSentences[index];
    }

    public void AddTextElmo(int index)
    {
        ElmoText.text += elmoSentences[index];
    }

    public void AddTextKaren(int index)
    {
        KarenText.text += karenSentences[index];
    }
}
