using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverCutscenes : MonoBehaviour
{
    public string SceneName;

    void Awake()
    {
        SceneManager.LoadScene(SceneName);
    }
}
