using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "House", menuName = "Scriptable Objects/BuildingThemeData")]
public class BuildingThemeData : ScriptableObject
{
    public string titleName;

    public List<GameObject> housePrefabs;
    
    public GameObject GetRandomPrefab()
    {
        if(housePrefabs == null || housePrefabs.Count == 0)
        {
            Debug.LogError("Buildingrefab list is empty" + this.titleName);
            return null;
        }
        int randomIndex = Random.Range(0, housePrefabs.Count);
        return housePrefabs[randomIndex];
    }
}
