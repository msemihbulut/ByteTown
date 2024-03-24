using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class City : MonoBehaviour
{
    [Header("City Properties")]
    public int money;
    public int currentPopulation;
    public int currentJobs;
    public int currentFood;
    public int maxPopulation;
    public int maxJobs;
    public int incomePerJob;
    public int dayCount;
    public int smartCityPoints;

    [Header("Stats Text")]
    public Text populationText;
    public Text moneyText;
    public Text jobText;
    public Text foodText;
    public Text dateText;

    [Header("Win and Lose Text")]
    public GameObject winOrLosePanel;
    public Text winText;
    public Text loseText;

    public Button endDayButton;

    public List<Building> buildings = new List<Building>();

    public static City instance;

    public bool isGameFinished = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateStatText();
        dateText.text = (++dayCount).ToString() + ". Gün";
    }

    public void EndDay()
    {
        CalculateMoney();
        CalculatePopulation();
        CalculateJobs();
        CalculateFood();
        UpdateStatText();
        dateText.text = (++dayCount).ToString() + ". Gün";

        if(dayCount == 31)
        {
            endDayButton.enabled = false;
            CheckWinOrLose();
        }
    }

    public void OnPlaceBuilding(Building building)
    {
        money -= building.preset.cost;
        maxPopulation += building.preset.population;
        maxJobs += building.preset.jobs;
        smartCityPoints += building.preset.smartCityPoint;
        buildings.Add(building);
        UpdateStatText();
    }
    public void OnRemoveBuilding(Building building)
    {
        money += building.preset.cost;
        maxPopulation -= building.preset.population;
        maxJobs -= building.preset.jobs;
        smartCityPoints -= building.preset.smartCityPoint;
        Destroy(building.gameObject);
        buildings.Remove(building);
        UpdateStatText();
    }

    void UpdateStatText()
    {
        moneyText.text = "$" + money.ToString();
        populationText.text =  maxPopulation.ToString();
        jobText.text = maxJobs.ToString();
        foodText.text = currentFood.ToString();
    }

    void CalculateMoney()
    {
        if(money < 0)
        {
            isGameFinished = true;
            winOrLosePanel.SetActive(true);
            loseText.gameObject.SetActive(true);
        }

        money += currentJobs * incomePerJob;
        
        foreach(Building building in buildings)
        {
            money += building.preset.costPerTurn;
        }
    }

    void CalculatePopulation()
    {
        if(currentFood >= currentPopulation && currentPopulation < maxPopulation)
        {
            currentFood -= currentPopulation / 4;
            currentPopulation = Mathf.Min(currentPopulation + (currentFood / 4), maxPopulation);
        }
        else if(currentFood < currentPopulation)
        {
            currentPopulation = currentFood;
        }            
    }

    void CalculateJobs()
    {
        currentJobs = Mathf.Min(currentPopulation, maxJobs);
    }

    void CalculateFood()
    {
        currentFood = 0;
        foreach(Building building in buildings)
        {
            currentFood += building.preset.food;
        }
    }

    public void CheckWinOrLose()
    {
        isGameFinished = true;
        winOrLosePanel.SetActive(true);

        if(currentFood >= maxPopulation && maxJobs >= (((int)(maxPopulation / 10) ) * 9) && smartCityPoints >= 400)
        {
            winText.gameObject.SetActive(true);
        }
        else
        {
            loseText.gameObject.SetActive(true);
        }
        PlayerPrefs.SetFloat("HighScore", (float)smartCityPoints);
    }
}
