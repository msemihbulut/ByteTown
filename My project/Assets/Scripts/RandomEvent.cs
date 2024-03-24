using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class RandomEvent : MonoBehaviour
{
    public List<Text> eventList;
    public List<float> smartCityPointList;
    public List<float> costList;

    public GameObject eventPanel;

    public int size;
    int index;

    
    void Start()
    {       
            InvokeRepeating("TriggerEvent", Random.Range(120, 150), Random.Range(180, 240));      
    }


    public void TriggerEvent()
    {
        if(City.instance.isGameFinished == true)
        {
            return;
        }

        if (size == 0)
        {
            return;
        }
        else
        {
            eventPanel.SetActive(true);
            index = Random.Range(0, size);
            eventList[index].gameObject.SetActive(true);
        }     
    }

    public void YesButton()
    {
        City.instance.smartCityPoints += (int)smartCityPointList[index];
        City.instance.money -= (int)costList[index];
        eventPanel.SetActive(false);
        eventList[index].gameObject.SetActive(false);
        eventList.RemoveAt(index);
        smartCityPointList.RemoveAt(index);
        costList.RemoveAt(index);
        size--;
    }

    public void NoButton()
    {
        City.instance.smartCityPoints -= (int)smartCityPointList[index];
        eventPanel.SetActive(false);
        eventList[index].gameObject.SetActive(false);
        eventList.RemoveAt(index);
        smartCityPointList.RemoveAt(index);
        costList.RemoveAt(index);
        size--;
    }
}
