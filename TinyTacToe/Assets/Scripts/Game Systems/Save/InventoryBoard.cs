using UnityEngine;
using System.Collections.Generic;

[System.Serializable]

[CreateAssetMenu(fileName ="Board", menuName = "ScriptableObjects/InventoryBoard")]
public class InventoryBoard : ScriptableObject
{
    [SerializeField]private List<BoardData> boardCollections = new List<BoardData>();

    public void AddBoard(TileState[] layout)
    {
        var data = new BoardData
        {
            boardLayout = (TileState[])layout.Clone(),
        };

        boardCollections.Add(data);
    }

    public List<BoardData> GetAllBoards() => boardCollections;
}
