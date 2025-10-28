using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    public BuildingThemeData house;
    private Transform point;
    [SerializeField] private bool isSpawning;
    [SerializeField] private float offset = 0.5f;
    
    private void Start()
    {
        point =  transform.Find("SpawnPoint");
    }
    
    public void BuildRandom()
    {
        GameObject gameObjectToBuild = house.GetRandomPrefab();

        if(gameObjectToBuild != null && isSpawning == false)
        {
            Vector3 spawnPos = point.position + Vector3.up * offset;
            GameObject newBuilding = Instantiate(gameObjectToBuild, spawnPos, Quaternion.identity);

            newBuilding.transform.SetParent(transform);

            isSpawning = true;
        }
    }
    
}
