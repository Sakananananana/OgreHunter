using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonBehaviour : MonoBehaviour
{
    public GameObject playerChar;
    public GameObject gameCtrl;
    public GameObject ogreChar;
    public GameObject BgMusicStart;
    Animator ogreAnim;
    public Animator ogreAnimChild;
    Rigidbody ogreRb;


    public void StartGame()
    {
        gameCtrl.SetActive(true);
        ogreAnim = ogreChar.GetComponent<Animator>();
        ogreAnim.SetBool("fly", true);
        
        Invoke("playerCharSetActive", 1.5f);
        Invoke("ogreScriptSetActive", 1f);
        Invoke("backgroundMusicSetActive", 1.5f);

        this.gameObject.SetActive(false);
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
}
