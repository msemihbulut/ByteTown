using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfos : MonoBehaviour
{

    public Text playerInfoText;
    public AudioSource backgroundMusic;

    string nickname;

    // Update is called once per frame
    void Update()
    {
        playerInfoText.text = PlayerPrefs.GetString("Nickname") + " adli oyuncunun en yuksek skoru: " + PlayerPrefs.GetFloat("HighScore");
    }

    public void OnEndEditText(string curNickname)
    {
        if(curNickname != PlayerPrefs.GetString("Nickname"))
        {
            PlayerPrefs.SetFloat("HighScore", 0);
        }

        nickname = curNickname;
        PlayerPrefs.SetString("Nickname", nickname);
    }

    public void OnValueChanged(float musicVolume)
    {
        backgroundMusic.volume = musicVolume;
    }
}
