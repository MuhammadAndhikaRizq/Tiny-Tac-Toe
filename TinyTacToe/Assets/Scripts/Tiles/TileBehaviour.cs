using System;
using NUnit.Framework;
using UnityEngine;

public enum TileState {Empty, Player, Computer}
public class TileBehaviour : MonoBehaviour
{
    [Header("Building Data")]
    public BuildingThemeData player;
    public BuildingThemeData computer;

    [Header("Spawn Settings")]
    private Transform centerPoint;
    public float offset = 0.05f;
    public bool isSpawning;

    public event Action<TileBehaviour> OnBuildBuilding;
    private TileState currentState = TileState.Empty;
    private GameObject currentBuilding;

    public bool IsEmpty => currentState == TileState.Empty;

    private void Start()
    {
        centerPoint = transform.Find("SpawnPoint");
    }
    
    public void PlacePlayerBuilding()
    {
        if (!IsEmpty) return;
        Build(player);
        currentState = TileState.Player;
        
    }

    public void PlaceComputerBuilding()
    {
        if (!IsEmpty) return;
        Build(computer);
        currentState = TileState.Computer;
    }
    
    private void Build(BuildingThemeData theme)
    {
        GameObject gameObjectToBuild = theme.GetRandomPrefab();

        if(gameObjectToBuild != null && isSpawning == false)
        {
            Vector3 spawnPos = centerPoint.position + Vector3.up * offset;
            currentBuilding = Instantiate(gameObjectToBuild, spawnPos, Quaternion.identity);

            currentBuilding.transform.SetParent(transform);

            isSpawning = true;
        }
    }
    
}
