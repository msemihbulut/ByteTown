using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfo : MonoBehaviour
{
    public GameObject buildingInfoTab;

    [Header("Building Info Tab Texts")]
    public Text costInfoTabText;
    public Text taxInfoTabText;
    public Text populationInfoTabText;
    public Text jobInfoTabText;
    public Text foodInfoTabText;
    public Text smartCityInfoTabText;

    public void ShowBuildingInfoTab(BuildingPreset preset)
    {
        costInfoTabText.text = "$" + preset.cost.ToString();
        taxInfoTabText.text = "$" + preset.costPerTurn.ToString();
        populationInfoTabText.text = preset.population.ToString();
        jobInfoTabText.text = preset.jobs.ToString();
        foodInfoTabText.text = preset.food.ToString();
        smartCityInfoTabText.text = preset.smartCityPoint.ToString();

        buildingInfoTab.SetActive(true);
    }

    public void CloseBuildingInfoTab()
    {
        buildingInfoTab.SetActive(false);
    }
}
