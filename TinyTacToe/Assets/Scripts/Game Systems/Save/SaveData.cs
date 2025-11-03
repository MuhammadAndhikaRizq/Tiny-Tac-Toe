using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class BoardBluePrint
{
    public TileState[] board = new TileState[9];

    public BoardBluePrint(TileState[] data)
    {
        board = (TileState[])data.Clone();
    }
}

[System.Serializable]
public class PlayerDeck
{
    public List<BoardBluePrint> bluePrints = new List<BoardBluePrint>();
}
