using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public TileBehaviour[] tiles;
   
    private bool playerTurn = true;

    private void OnEnable()
    {
        foreach(TileBehaviour tile in tiles)
        {
            TileMovement tileMovement = tile.GetComponent<TileMovement>();

            if(tileMovement != null)
            {
                tileMovement.OnBuild += OnTileSelected;
            }
        }
        
    }

    private void OnDisable()
    {
        foreach(TileBehaviour tile in tiles)
        {
            TileMovement tileMovement = tile.GetComponent<TileMovement>();

            if(tileMovement != null)
            {
                tileMovement.OnBuild -= OnTileSelected;
            }
        }
    }


    public void OnTileSelected(TileBehaviour tile)
    {
        if (!tile.IsEmpty) return;

        if (playerTurn)
        {
            tile.PlacePlayerBuilding();
            playerTurn = false;
            CheckWinCondition();
            Invoke(nameof(ComputerTurn), 0.5f);
        }
    }

    private void ComputerTurn()
    {
        var available = tiles.Where(t => t.IsEmpty).ToList();
        if (available.Count == 0) return;

        var randomTile = available[Random.Range(0, available.Count)];
        randomTile.PlaceComputerBuilding();
        playerTurn = true;
        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        
    }
   
}
