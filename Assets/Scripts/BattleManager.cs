using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    CardLoad CardLoad;

    public GameObject EffectHand;
    public GameObject BattleCardPrefab;
    
    public int drawCardAmount = 3;
    public int drawPokerAmount = 6;
    public List<Card> cardList = new List<Card>();

    // Start is called before the first frame update
    void Start()
    {
        CardLoad = GetComponent<CardLoad>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void throwHand()
    {

    }
    public void playerBuffDeal()
    {

    }
    public void MonsterBuffDeal()
    {

    }
    public void playerShieldHealthDeal()
    {

    }
    public void monsterShieldHealthDeal()
    {
        
    }
    public void playerDamageDeal()
    {

    }
    public void monsterDamageDeal()
    {

    }
    public void newTurnAlert()
    {

    }
    public void drawCard(int drawCardAmount)
    {
        List<GameObject> drawCardList = new List<GameObject>();

        for (int i = 0; i < drawCardAmount; i++)
        {
            GameObject newCard = GameObject.Instantiate(BattleCardPrefab, EffectHand.transform);
            newCard.GetComponent<CardDisplay>().card = CardLoad.RandomCard();
            
            drawCardList.Add(newCard);
        }
    }
    public void drawPoker(int drawPokerAmount)
    {

    }

    public static void turnEnd()
    {
        //throwHand();
        //playerBuffDeal();
        //MonsterBuffDeal();
        //playerShieldHealthDeal();
        //monsterShieldHealthDeal();
        //playerDamageDeal();
        //monsterDamageDeal();
        //newTurnAlert();
        //drawCard(drawCardAmount);
        //drawPoker(drawPokerAmount);
    }
}
