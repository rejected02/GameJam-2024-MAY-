using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;


    private void Awake()
    {
        instance = this;
    }
    public Animator startClip;
    public AudioClip tapClip;
    public AudioSource tapSource;
    public AudioSource GameAudio;
    private void Start()
    {
        GameAudio.enabled = false;
        StartCoroutine(EndIntro());
    }
    IEnumerator EndIntro()
    {
        yield return new WaitForSeconds(14);
        startClip.Play("IntroClip");
        if(AudioManager.instance.checkMusic == 1)
        GameAudio.enabled = true;
       // GetComponent<VideoPlayer>().enabled = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            startClip.Play("IntroClip");
            GameAudio.enabled = true;
            //GetComponent<VideoPlayer>().enabled = false;
        }
      
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Quit()
    {
       Application.Quit();
    }

    public void OptionButton()
    {

    }
} 
