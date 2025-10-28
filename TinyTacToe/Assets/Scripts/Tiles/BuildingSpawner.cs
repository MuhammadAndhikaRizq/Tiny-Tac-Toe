using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public BuildingThemeData house;
    [SerializeField] private float offset = 0.5f;
    
    public void BuildRandom()
    {
        Vector3 parent = transform.position;
        GameObject gameObjectToBuild = house.GetRandomPrefab();

        if(gameObjectToBuild != null)
        {
            Vector3 spawnPos = parent + Vector3.up * offset;
            Instantiate(gameObjectToBuild, spawnPos, Quaternion.identity);
        }
    }
    
}
