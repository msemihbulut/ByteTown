using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControllerInMainMenu : MonoBehaviour
{
    [Header("Sources")]
    public AudioSource src;
    public AudioClip mainMenuButtonClick;

    public void MainMenuButtonClick()
    {
        src.clip = mainMenuButtonClick;
        src.Play();
    }
}
