using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckLoad : MonoBehaviour
{
    public TextAsset deckData;
    public TextAsset cardData;
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

    public Card RandomDraw()
    {
        int drawId = cardListOfDeck[Random.Range(0, cardListOfDeck.Count)];
        Card card = null;

        string[] dataRow = cardData.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            else if (rowArray[0] == "##" && int.Parse(rowArray[1]) == drawId)
            {
                string cardName = rowArray[2];
                string cardDescription = rowArray[3];
                string cardEnergyRequired = rowArray[4];
                string cardObject = rowArray[5];
                card = new Card(drawId, cardName, cardDescription, cardEnergyRequired, cardObject);
                break;
            }
        }

        return card;
    }
}