using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsController : MonoBehaviour
{
    [Header("Sources")]
    public AudioSource src;
    public AudioClip toolbarButtonClick, placeBuildingSound, deleteBuildingSound;

    public static SoundEffectsController instance;

    public AudioSource backgroundMusic;

    private void Awake()
    {
        instance = this;
    }

    public void ToolbarButtonClick()
    {
        src.clip = toolbarButtonClick;
        src.Play();
    }

    public void PlaceBuildingSound()
    {
        src.clip = placeBuildingSound;
        src.Play();
    }

    public void DeleteBuildingSound()
    {
        src.clip = deleteBuildingSound;
        src.Play();
    }

    public void OnValueChanged(float musicVolume)
    {
        backgroundMusic.volume = musicVolume;
    }
}
