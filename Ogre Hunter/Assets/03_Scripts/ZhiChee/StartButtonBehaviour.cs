using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonBehaviour : MonoBehaviour
{
    public GameObject playerChar;
    public GameObject gameCtrl;
    public GameObject ogreChar;
    public GameObject BgMusicStart;
    public GameObject ScoreTxt;
    public GameObject pressToStartTxt;
    public GameObject cursor;

    Animator ogreAnim;
    public Animator ogreAnimChild;
    Rigidbody ogreRb;

    public AudioSource screamSource;
    public AudioClip screamClip;

    public Button clickToStart;

    public void StartGame()
    {
        gameCtrl.SetActive(true);
        ogreAnim = ogreChar.GetComponent<Animator>();
        ogreAnim.SetBool("fly", true);
        screamSource.PlayOneShot(screamClip);
        
        Invoke("playerCharSetActive", 1.5f);
        Invoke("ogreScriptSetActive", 1f);
        Invoke("backgroundMusicSetActive", 1.5f);
        Invoke("ScoreSetActive", 1.5f);

        clickToStart.interactable = false;
        pressToStartTxt.SetActive(false);
        cursor.SetActive(false);
        Invoke("SetStartFalse", 1.5f);
    }

    private void playerCharSetActive()
    {
        playerChar.SetActive(true);
    }

    private void ogreScriptSetActive()
    {
        ogreAnim.enabled = false;

        ogreAnimChild.SetBool("run", true);
        ogreRb = ogreChar.GetComponent<Rigidbody>();
        ogreRb.constraints = RigidbodyConstraints.None;
        ogreRb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void backgroundMusicSetActive()
    {
        BgMusicStart.SetActive(true);
    }

    private void ScoreSetActive()
    {
        ScoreTxt.SetActive(true);
    }

    private void SetStartFalse()
    {
        this.gameObject.SetActive(false);
    }
}
