using UnityEngine;

public class AIController : MonoBehaviour
{
    private const TileState PlayerMaker = TileState.Player;
    private const TileState ComputerMaker = TileState.Computer;

    private readonly int[,] winConditions = new int[,]
    {
        {0, 1, 2}, {3, 4, 5}, {6, 7, 8}, 
        {0, 3, 6}, {1, 4, 7}, {2, 5, 8}, 
        {0, 4, 8}, {2, 4, 6}
    };

    public int FindBestMove(TileState[] boardState)
    {
        int bestScore = int.MinValue;
        int bestMove = -1;

        TileState[] simulationBoard = (TileState[])boardState.Clone();
        for (int i = 0; i < 9; i++)
        {
            if (simulationBoard[i] == TileState.Empty)
            {
                simulationBoard[i] = ComputerMaker;
                int moveScore = Minimax(simulationBoard, false);
                simulationBoard[i] = TileState.Empty;

                if (moveScore > bestScore)
                {
                    bestScore = moveScore;
                    bestMove = i;
                }
            }
        }

        return bestMove;
    }

    private int Minimax(TileState[] board, bool isMaximizingTurn)
    {
        int score = EvaluateBoard(board);
        if (score != int.MinValue)
        {
            return score;
        }

        if (isMaximizingTurn)
        {
            int bestScore = int.MinValue;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == TileState.Empty)
                {
                    board[i] = ComputerMaker;
                    bestScore = Mathf.Max(bestScore, Minimax(board, false));
                    board[i] = TileState.Empty;
                }
            }
            return bestScore;

        }
        else
        {
            int bestScore = int.MaxValue;
            for (int i = 0; i < 9; i++)
            {
                if (board[i] == TileState.Empty)
                {
                    board[i] = PlayerMaker;
                    bestScore = Mathf.Min(bestScore, Minimax(board, true));
                    board[i] = TileState.Empty;
                }
            }
            return bestScore;
        }

    }

    private int EvaluateBoard(TileState[] currentBoard)
    {
        for (int i = 0; i < 8; i++)
        {
            int a = winConditions[i, 0];
            int b = winConditions[i, 1];
            int c = winConditions[i, 2];

            if (currentBoard[a] != TileState.Empty &&
                currentBoard[a] == currentBoard[b] &&
                currentBoard[a] == currentBoard[c])
            {
                return (currentBoard[a] == ComputerMaker) ? 10 : -10;
            }
        }

        for (int i = 0; i < 9; i++)
        {
            if (currentBoard[i] == TileState.Empty)
            {
                return int.MinValue;
            }
        }

        return 0;
    }
    
    public bool CheckWinCondition(TileState[] boardState)
    {
        int score = EvaluateBoard(boardState);
        return score != int.MinValue; 
    }
}
