using UnityEngine;
using System.IO;
public class SaveManager : MonoBehaviour
{
    // public static SaveManager Instance { get; private set; }

    // private string savePath;

    // private void Awake()
    // {
    //     if (Instance != null && Instance != this)
    //     {
    //         Destroy(gameObject);
    //     }
    //     else
    //     {
    //         Instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }

    //     savePath = Path.Combine(Application.persistentDataPath, "deck.json");
    // }

    // public void SaveDeck(PlayerDeck deck)
    // {
    //     string jsonDeck = JsonUtility.ToJson(deck, true);

    //     File.WriteAllText(savePath, jsonDeck);

    // }
    
    // public PlayerDeck LoadDeck()
    // {
    //     if (File.Exists(savePath))
    //     {
    //         string jsonDeck = File.ReadAllText(savePath);
    //         PlayerDeck deck = JsonUtility.FromJson<PlayerDeck>(jsonDeck);
    //         return deck;
    //     }
    //     else
    //     {
    //         return new PlayerDeck();
    //     }
    // }


}
