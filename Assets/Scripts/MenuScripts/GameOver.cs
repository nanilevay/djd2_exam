using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public ViewController vc;

    public void ZenEnd()
    {
        vc.ToggleSuspects(true);
        StartCoroutine(Finish());
    }

    IEnumerator Finish()
    {
        GameObject.Find("Fade").GetComponent<Animator>().SetBool("fading", false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("ZenEnd");
    }
}
