using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuildingSystem : MonoBehaviour
{
    public static GridBuildingSystem instance { get; private set; }

    [SerializeField] Grid grid;
    [SerializeField] private BuildingDataBaseSO buildingDataBase;
    private int choosedBuildingIndex = -1;

    private Building ghost;


    private IGridSystemInputProvider gridSystemInputProvider;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    public void SetGridSystemInputProvider(IGridSystemInputProvider gridSystemInputProvider)
    {
        if (this.gridSystemInputProvider != null)
        {
            Debug.LogError("IGridSystemInputProvider is alredy assigned");
            return;
        }
        this.gridSystemInputProvider = gridSystemInputProvider;


        this.gridSystemInputProvider.buildingChoosed += ChooseBuilding;
        this.gridSystemInputProvider.placingButtonPressed += StartPlacing;

    }
    private void ChooseBuilding(int ID)
    {
        choosedBuildingIndex = buildingDataBase.Buildings.FindIndex(b => b.ID == ID);
        if(choosedBuildingIndex == -1)
        {
            Debug.LogError($"Building with index {ID} does not exist");
            return;
        }
    }
    private void StartPlacing()
    {
        if (choosedBuildingIndex == -1)
        {
            return;
        }
        ghost = Instantiate(buildingDataBase.Buildings[choosedBuildingIndex].Prefab);
    }

    private void Place()
    {

    }
}
