using System.Collections.Generic;
using UnityEngine;

public class BoarddSpawner : MonoBehaviour
{
    [SerializeField] private InventoryBoard inventory;
    [SerializeField] private GameObject playerBuildingPrefab;
    [SerializeField] private GameObject computerBuildingPrefab;

    [SerializeField] private Transform gridParent;
    [SerializeField] private float spacing = 0.2f;

    public void SpawnBoard()
    {
        List<BoardData> allBoards = inventory.GetAllBoards();

        if (allBoards == null || allBoards.Count == 0)
        {
            return;
        }

        BoardData boardToSpawn = allBoards[0];

        BuilGridFromData(boardToSpawn);
    }
    
    private void BuilGridFromData(BoardData data)
    {
        for(int i = 0; i < data.boardLayout.Length; i++)
        {
            TileState state = data.boardLayout[i];

            GameObject prefabToSpawn = null;

            if (state == TileState.Player)
            {
                prefabToSpawn = playerBuildingPrefab;
            }
            else if (state == TileState.Computer)
            {
                prefabToSpawn = computerBuildingPrefab;
            }

            if (prefabToSpawn != null)
            {
                // Hitung posisi di grid (format 3x3)
                float xPos = (i % 3) * spacing;
                float zPos = (i / 3) * spacing;
                Vector3 spawnPos = new Vector3(xPos, 0, zPos);

                // Tentukan induknya
                Transform parent = gridParent != null ? gridParent : null;

                // Jika gridParent di-set, atur posisi relatif
                if (parent != null)
                {
                    spawnPos += parent.position;
                }

                // Spawn bangunannya!
                Instantiate(prefabToSpawn, spawnPos, Quaternion.identity, parent);
            }
        }
    }
}
