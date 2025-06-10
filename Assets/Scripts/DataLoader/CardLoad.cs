using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLoad : MonoBehaviour
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
                string cardEnergyRequired = rowArray[4];
                string cardObject = rowArray[5];
                Card card = new Card(Id, cardName, cardDescription, cardEnergyRequired, cardObject);
                cardList.Add(card);
            }
        }
    }

    public Card RandomCard()
    {
        Card card = cardList[Random.Range(0, cardList.Count)];
        return card;
    }
}
