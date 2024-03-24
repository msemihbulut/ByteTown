using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolbarTransations : MonoBehaviour
{
    [Header("Toolbars")]
    public GameObject toolbar;
    public GameObject houseToolbar;
    public GameObject jobToolbar;
    public GameObject foodToolbar;
    public GameObject roadToolbar;
    public GameObject smartCityToolbar;
    public GameObject treeToolbar;


    public void BackToToolbar(GameObject currentToolbar)
    {
        currentToolbar.SetActive(false);
        toolbar.SetActive(true);
    }

    public void OpenHouseToolbar(GameObject currentToolbar)
    {
        currentToolbar.SetActive(false);
        houseToolbar.SetActive(true);
    }

    public void OpenJobToolbar(GameObject currentToolbar)
    {
        currentToolbar.SetActive(false);
        jobToolbar.SetActive(true);
    }

    public void OpenFoodToolbar(GameObject currentToolbar)
    {
        currentToolbar.SetActive(false);
        foodToolbar.SetActive(true);
    }

    public void OpenRoadToolbar(GameObject currentToolbar)
    {
        currentToolbar.SetActive(false);
        roadToolbar.SetActive(true);
    }

    public void OpenSmartCityToolbar(GameObject currentToolbar)
    {
        currentToolbar.SetActive(false);
        smartCityToolbar.SetActive(true);
    }

    public void OpenTreeToolbar(GameObject currentToolbar)
    {
        currentToolbar.SetActive(false);
        treeToolbar.SetActive(true);
    }

}
