using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InfoSceneTexts : MonoBehaviour
{
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    public Text text6;
    public Text text7;

    public Button nextPageButton;
    public Button startGameButton;

    int buttonCounter = 0;
    
    public void NextPage()
    {
        switch( buttonCounter )
        {
            case 0:
                text1.gameObject.SetActive(false);
                text2.gameObject.SetActive(true);
                buttonCounter++;
                break;
            case 1:
                text2.gameObject.SetActive(false);
                text3.gameObject.SetActive(true);
                buttonCounter++;
                break;
            case 2:
                text3.gameObject.SetActive(false);
                text4.gameObject.SetActive(true);
                buttonCounter++;
                break;
            case 3:
                text4.gameObject.SetActive(false);
                text5.gameObject.SetActive(true);
                buttonCounter++;
                break;
            case 4:
                text5.gameObject.SetActive(false);
                text6.gameObject.SetActive(true);
                buttonCounter++;
                break;
            case 5:
                text6.gameObject.SetActive(false);
                text7.gameObject.SetActive(true);
                nextPageButton.gameObject.SetActive(false);
                startGameButton.gameObject.SetActive(true);
                break;
        }
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
