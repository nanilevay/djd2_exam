using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCutscenes : MonoBehaviour
{ 

    void Awake()
    {
        SceneManager.LoadScene("GameOverF");
    }
}
