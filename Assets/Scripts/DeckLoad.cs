using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckLoad : MonoBehaviour
{
    public TextAsset deckData;
    public List<int> cardListOfDeck = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadDeckData()
    {
        string[] dataRow = deckData.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            else if (rowArray[0] == "##")
            {
                int Amount = int.Parse(rowArray[2]);
                for (int i = 0; i < Amount; i++)
                {
                    int cardId = int.Parse(rowArray[1]);
                    cardListOfDeck.Add(cardId);
                }
            }
        }
    }
}