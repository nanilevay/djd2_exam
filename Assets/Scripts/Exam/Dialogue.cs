using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject panel;

    public NoteHandler notes;

    public TextMeshProUGUI textDisplay;

    public string[] introSentences;

    public string[] zenRoomSentences;

    public string[] storageSentences;

    public string[] bloodClueSentences;

    public string[] mirrorSentences;

    public string[] cluesSentences;

    public string[] bloodInspectSentences;

    public string[] kitSpeechSentences;

    public string[] KarenSuspicionSentences;

    public string[] investigationStartSentences;

    public string[] suspectsSentences;

    public string[] GoToZenSentence;

    public string[] finalSentences;

    public string [] sentences;

    public int index = 0;

    public float TypingSpeed;

    public bool intro = true;

    public bool zen = false;

    public bool final = false;

    public bool zenMirror = false;

    public bool storage = false;

    public bool clues = false;

    public bool Suspects = false;

    public bool kitSpeech = false;

    public bool bloodMessage = false;

    public bool GoToZenRoom = false;

    public bool bloodMessageInspect = false;

    public bool investigationStart = false;

    public bool StorageEnd = false;

    public bool KarenSuspicion = false;

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
        if(panel.activeSelf)
        {
           
            if (player != null)
                player.GetComponent<CharacterController>().enabled = false;
            if (camera != null)
            camera.enabled = false;
        }

        
        
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

        if (kitSpeech)
        {
            panel.SetActive(true);
            sentences = kitSpeechSentences;
            index = -1;
            textDisplay.text = "";
            kitSpeech = false;
        }

        if (investigationStart)
        {
            panel.SetActive(true);
            sentences = investigationStartSentences;
            index = -1;
            textDisplay.text = "";
            investigationStart = false;
        }

        if (bloodMessage)
        {
            panel.SetActive(true);
            sentences = bloodClueSentences;
            index = -1;
            textDisplay.text = "";
            bloodMessage = false;
            notes.AddTextElmo(0);
        }

        if (bloodMessageInspect)
        {
            panel.SetActive(true);
            sentences = bloodInspectSentences;
            index = -1;
            textDisplay.text = "";
            bloodMessageInspect = false;
            notes.AddTextElmo(0);
            notes.AddTextElmo(1);
            notes.AddTextElmo(2);
            notes.AddTextElmo(3);
        }

        if (zenMirror)
        {
            panel.SetActive(true);
            sentences = mirrorSentences;
            notes.AddTextZen(2);
            index = -1;
            textDisplay.text = "";
            zenMirror = false;
        }


        if (GoToZenRoom)
        {
            panel.SetActive(true);
            sentences = GoToZenSentence;
            index = -1;
            textDisplay.text = "";
            GoToZenRoom = false;
        }

        if (storage)
        {
            panel.SetActive(true);
            sentences = storageSentences;
            index = -1;
            textDisplay.text = "";
            storage = false;
        }

        if (final)
        {
            panel.SetActive(true);
            sentences = finalSentences;
            index = -1;
            textDisplay.text = "";
            final = false;
        }

        if (KarenSuspicion)
        {
            panel.SetActive(true);
            sentences = KarenSuspicionSentences;
            index = -1;
            textDisplay.text = "";
            KarenSuspicion = false;
        }

        if (Suspects)
        {
            panel.SetActive(true);
            sentences = suspectsSentences;
            index = -1;
            textDisplay.text = "";
            StorageEnd = true;
            Suspects = false;
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
