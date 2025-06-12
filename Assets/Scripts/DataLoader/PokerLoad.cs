using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerLoad : MonoBehaviour
{
    public static List<Poker> pokerList = new List<Poker>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void LoadPokerData()
    {
        for (int i = 0; i < 13; i++)
        {
            int pokerNumber = i + 1;
            for (int j = 0; j < 4; j++)
            {
                if (j == 1)
                {
                    string pokerSuit = "♠";
                    Poker poker = new Poker(pokerNumber, pokerSuit);
                    pokerList.Add(poker);
                }
                else if (j == 2)
                {
                    string pokerSuit = "♥";
                    Poker poker = new Poker(pokerNumber, pokerSuit);
                    pokerList.Add(poker);
                }
                else if (j == 3)
                {
                    string pokerSuit = "♦";
                    Poker poker = new Poker(pokerNumber, pokerSuit);
                    pokerList.Add(poker);
                }
                else
                {
                    string pokerSuit = "♣";
                    Poker poker = new Poker(pokerNumber, pokerSuit);
                    pokerList.Add(poker);
                }
            }
        }
    }

    public Poker RandomDrawPoker()
    {
        Poker poker = pokerList[Random.Range(0, pokerList.Count)];
        pokerList.Remove(poker);
        return poker;
    } 
}
