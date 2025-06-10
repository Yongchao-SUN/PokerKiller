using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    DeckLoad DeckLoad;
    PlayerLoad PlayerLoad;

    public GameObject EffectHand;
    public GameObject BattleCardPrefab;
    public GameObject NewTurnPopupPrefab;
    
    public int drawCardAmount = 3;
    public int drawPokerAmount = 6;
    public float popTime = 0.5f;
    public int energyChargeAmount;
    public List<int> cardListOfDeck = new List<int>();

    List<GameObject> drawCardList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        DeckLoad = GetComponent<DeckLoad>();
        PlayerLoad = GetComponent<PlayerLoad>();
        energyChargeAmount = PlayerLoad.LoadPlayerData("maxEnergy");
    }

    // Update is called once per frame
    void Update()
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
        Instantiate(NewTurnPopupPrefab, new Vector2(Screen.width / 2f, Screen.height / 2f), Quaternion.identity);
    }
    public void throwHand()
    {
        foreach (var card in drawCardList)
        {
            Destroy(card);
        }
        drawCardList.Clear();
    }
    public void throwPoker()
    {
        
    }
    public void drawCard(int drawCardAmount)
    {
        for (int i = 0; i < drawCardAmount; i++)
        {
            GameObject newCard = GameObject.Instantiate(BattleCardPrefab, EffectHand.transform);
            newCard.GetComponent<CardDisplay>().card = DeckLoad.RandomDraw();
            
            drawCardList.Add(newCard);
        }
    }
    public void drawPoker(int drawPokerAmount)
    {

    }
    public void energyCharge(int energyChargeAmount)
    {
        
    }

    public void turnEnd()
    {
        //playerBuffDeal();
        //MonsterBuffDeal();
        //playerShieldHealthDeal();
        //monsterShieldHealthDeal();
        //playerDamageDeal();
        //monsterDamageDeal();
        newTurnAlert();
        throwHand();
        //throwPoker();
        drawCard(drawCardAmount);
        //drawPoker(drawPokerAmount);
        //energyCharge();
    }

    public void BattleWin()
    {
        SceneLoadManager.LoadSceneByName("BattleReward");
    }

    public void BattleLose()
    {

    }
}
