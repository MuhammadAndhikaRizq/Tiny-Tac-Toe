using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName ="Board", menuName = "ScriptableObjects/InventoryBoard")]
public class InventoryBoard : ScriptableObject
{
    public List<GameObject> boardCollections;

    public void AddBoard(GameObject board)
    {
        if(!boardCollections.Contains(board))
            boardCollections.Add(board);
    }
}
