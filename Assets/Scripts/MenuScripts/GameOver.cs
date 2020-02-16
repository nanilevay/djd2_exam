using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public ViewController vc;

    public void ZenEnd()
    {
        //vc.ToggleSuspects(true);
        StartCoroutine(Finish("ZenEnd"));
    }

    public void PabloEnd()
    {
        //vc.ToggleSuspects(true);
        StartCoroutine(Finish("PabloEnd"));
    }

    public void KarenEnd()
    {
        //vc.ToggleSuspects(true);
        StartCoroutine(Finish("KarenEnd"));
    }

    public void ElmoEnd()
    {
        //vc.ToggleSuspects(true);
        StartCoroutine(Finish("ElmoEnd"));
    }

    public void LockEnd()
    {
        //vc.ToggleSuspects(true);
        StartCoroutine(Finish("LockEnd"));
    }

    IEnumerator Finish(string name)
    {
        GameObject.Find("Fade").GetComponent<Animator>().SetBool("fading", false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(name);
    }
}
