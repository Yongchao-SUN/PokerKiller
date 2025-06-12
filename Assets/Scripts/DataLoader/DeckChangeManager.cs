using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DeckChangeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void CardAddToDeck(int cardId)
    {
        string filePath = "Assets/Data/deckData.csv";
        var lines = File.ReadAllLines(filePath);

        var columns = lines[cardId + 1].Split(',');
        columns[2] += 1;
        lines[cardId + 1] = string.Join(",", columns);

        File.WriteAllLines(filePath, lines);
    } 

    public static void CardDeleteFromDeck(int cardId)
    {
        string filePath = "deckData.csv";
        var lines = File.ReadAllLines(filePath);

        var columns = lines[cardId + 1].Split(',');
        columns[2] += -1;
        lines[cardId + 1] = string.Join(",", columns);

        File.WriteAllLines(filePath, lines);
    }
}
