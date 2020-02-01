using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(Finish());
            
        }
    }

    IEnumerator Finish()
    {
        GameObject.Find("Fade").GetComponent<Animator>().SetBool("fading", false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOverF");
    }
}
