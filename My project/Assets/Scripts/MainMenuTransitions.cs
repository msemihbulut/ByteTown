using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTransitions : MonoBehaviour
{
    [Header("Game Objects")]
    public GameObject mainMenu;
    public GameObject howToPlay;
    public GameObject settings;

    [Header("Pages")]
    public GameObject firstPage;
    public GameObject secondPage;

    public void BackToMainMenu(GameObject currentToolbar)
    {
        currentToolbar.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OpenGameScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenHowToPlay(GameObject currentToolbar)
    {
        currentToolbar.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void OpenSettings(GameObject currentToolbar)
    {
        currentToolbar.SetActive(false);
        settings.SetActive(true);
    }

    public void OpenPage(GameObject currentPage)
    {
        if(currentPage.name == "FirstPage")
        {
            firstPage.SetActive(false);
            secondPage.SetActive(true);
        }
        else
        {
            firstPage.SetActive(true);
            secondPage.SetActive(false);
        }
    }


    public void ExitGame()
    {
        Application.Quit();
    }


}
