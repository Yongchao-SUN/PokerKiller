using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public TextAsset cardData;
    public List<Card> cardList = new List<Card>();

    // Start is called before the first frame update
    void Start()
    {
        LoadCardData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadCardData()
    {
        string[] dataRow = cardData.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            else if (rowArray[0] == "##")
            {
                int Id = int.Parse(rowArray[1]);
                string cardName = rowArray[2];
                string cardDescription = rowArray[3];
                Card card = new Card(Id, cardName, cardDescription);
                cardList.Add(card);
            }
        }
    }

    public Card RandomCard()
    {
        int cardId = Random.Range(0, cardList.Count);
        return cardId;
    }
}
