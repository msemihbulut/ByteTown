using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingPlacement : MonoBehaviour
{
    private bool currentlyPlacing;
    private bool currentlyDeleting;

    private BuildingPreset currentBuildingPreset;

    private float indicatorUpdateTime = 0.05f;
    private float lastUpdateTime;
    private Vector3 currentIndicatorPosition;

    [Header("Indicators")]
    public GameObject placementIndicator;
    public GameObject deleteIndicator;

    public GameObject notEnoughMoneyText;

    public void BeginNewBuildingPlacement(BuildingPreset preset)
    {
        if(City.instance.money < preset.cost)
        {
            StartCoroutine(DelayText(2));
            return;
        }

        currentlyPlacing = true;
        currentBuildingPreset = preset;
        placementIndicator.SetActive(true);
    }

    void CancelBuildingPlacement()
    {
        currentlyPlacing = false;
        placementIndicator.SetActive(false);
    }

    public void ToggleDelete()
    {
        currentlyDeleting = !currentlyDeleting;
        deleteIndicator.SetActive(currentlyDeleting);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CancelBuildingPlacement();
        }

        if(Time.time - lastUpdateTime > indicatorUpdateTime)
        {
            lastUpdateTime = Time.time;
            currentIndicatorPosition = Selector.instance.GetCurrentTilePosition();

            if(currentlyPlacing)
            {
                placementIndicator.transform.position = currentIndicatorPosition;
            }
            else if(currentlyDeleting)
            {
                deleteIndicator.transform.position = currentIndicatorPosition;
            }
        }

        if(Input.GetMouseButtonDown(0) && currentlyPlacing)
        {
            PlaceBuilding();
        }
        else if(Input.GetMouseButtonDown(0) && currentlyDeleting)
        {
            Delete();
        }
    }

    void PlaceBuilding()
    {
        GameObject buildingObject = Instantiate(currentBuildingPreset.prefab, currentIndicatorPosition, Quaternion.identity);
        City.instance.OnPlaceBuilding(buildingObject.GetComponent<Building>());
        CancelBuildingPlacement();
        SoundEffectsController.instance.PlaceBuildingSound();
    }

    void Delete()
    {
        Building buildingToDestroy = City.instance.buildings.Find(x => x.transform.position == currentIndicatorPosition);
        if(buildingToDestroy != null)
        {
            City.instance.OnRemoveBuilding(buildingToDestroy);
        }
        SoundEffectsController.instance.DeleteBuildingSound();
    }

    private IEnumerator DelayText(float duration)
    {
        notEnoughMoneyText.SetActive(true);
        yield return new WaitForSeconds(duration);
        notEnoughMoneyText.SetActive(false);
    }

}
