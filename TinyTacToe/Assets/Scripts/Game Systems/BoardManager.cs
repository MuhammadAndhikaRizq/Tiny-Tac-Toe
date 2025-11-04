using UnityEngine;
using System.IO;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { get; private set;}
    [SerializeField] private InventoryBoard boardToSave;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    public void AddToInventory(GameObject boardActive)
    {
        boardToSave.AddBoard(boardActive);
    }
}
