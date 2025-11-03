using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public TileBehaviour[] tiles;
    [SerializeField] private AIController aIController;

    [Header("Game State")]
    private bool playerTurn = true;
    private bool gameIsOver = false;

    private TileState[] boardState;
    private PlayerDeck playerDeck;

    public const TileState PlayerMaker = TileState.Player;
    public const TileState ComputerMaker = TileState.Computer;

    private void Start()
    {
        boardState = new TileState[9];
        for (int i = 0; i < 9; i++)
        {
            boardState[i] = TileState.Empty;
        }
        
        playerDeck = SaveManager.Instance.LoadDeck();
    }

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
            if(tile != null)
            {
                TileMovement tileMovement = tile.GetComponent<TileMovement>();

                 if(tileMovement != null)
                {
                    tileMovement.OnBuild -= OnTileSelected;
                }
            }
        }
    }


    public void OnTileSelected(TileBehaviour tile)
    {
        Debug.Log("Kepanggil ga nihh");
        if (!playerTurn || gameIsOver || !tile.IsEmpty) return;

        Debug.Log("Holaa");

        int clickedIndex = -1;
        
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] == tile)
            {
                clickedIndex = i;
                break;
            }
        }

        if (clickedIndex == -1) return;

        if (boardState[clickedIndex] == TileState.Empty)
        {
            boardState[clickedIndex] = PlayerMaker;
            tile.PlacePlayerBuilding();
            playerTurn = false;

            if(aIController.CheckWinCondition(boardState) == false)
            {
                Invoke(nameof(ComputerTurn), 0.5f);
            }
            else
            {
                EndGame(PlayerMaker);
            }
        }
    }

    private void ComputerTurn()
    {
        int bestMoveIndex = aIController.FindBestMove(boardState);

        if (bestMoveIndex != -1)
        {
            boardState[bestMoveIndex] = ComputerMaker;
            tiles[bestMoveIndex].PlaceComputerBuilding();
            playerTurn = true;

            if (aIController.CheckWinCondition(boardState))
            {
                EndGame(ComputerMaker);
            }
        }
        else
        {
            EndGame(TileState.Empty);
        }
    }
    
    private void EndGame(TileState winner)
    {
        gameIsOver = true;

        if (winner == PlayerMaker)
        {
            Debug.Log("Player Menang!");
        }
        else if (winner == ComputerMaker)
        {
            Debug.Log("Komputer Menang!");
        }
        else
        {
            Debug.Log("Seri!");
        }

        BoardBluePrint newBluePrint = new BoardBluePrint(boardState);
        playerDeck.bluePrints.Add(newBluePrint);
        SaveManager.Instance.SaveDeck(playerDeck);

        Debug.Log("Board Save to deck");
    }
   
}
