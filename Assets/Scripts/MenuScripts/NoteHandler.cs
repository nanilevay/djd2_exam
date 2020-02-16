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

    public bool noteTaking;


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
        if(!LockText.text.Contains(introSentences[index]))
            LockText.text += introSentences[index];
    }

    public void AddTextZen(int index)
    {
        if (!ZenText.text.Contains(zenSentences[index]))
            ZenText.text += zenSentences[index];
    }

    public void AddTextPablo(int index)
    {
        if (!PabloText.text.Contains(pabloSentences[index]))
            PabloText.text += pabloSentences[index];
    }

    public void AddTextElmo(int index)
    {
        if (!ElmoText.text.Contains(elmoSentences[index]))
            ElmoText.text += elmoSentences[index];
    }

    public void AddTextKaren(int index)
    {
        if (!KarenText.text.Contains(karenSentences[index]))
            KarenText.text += karenSentences[index];
    }
}
