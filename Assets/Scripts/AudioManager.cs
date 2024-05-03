using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
  public static AudioManager instance;
    public int checkSound;
   public  int checkMusic;
    
    private void Awake()
    {
        instance = this;
        

    }

    private void Start()
    {
        //sfx
        if (PlayerPrefs.HasKey("Sonud"))
            checkSound = PlayerPrefs.GetInt("Sonud");
        else
            checkSound = 1;
        if (checkSound == 1)
        {
            UiManager.instance.tapSource.enabled = true;
        }
        else
        {
            UiManager.instance.tapSource.enabled = false;
        }
        //music
        if (PlayerPrefs.HasKey("Music"))
            checkSound = PlayerPrefs.GetInt("Music");
        else
            checkMusic = 1;

        if (checkMusic == 1)
        {
            UiManager.instance.GameAudio.enabled = true;
        }
        else
        {
            UiManager.instance.GameAudio.enabled = false;
        }
    }
}
