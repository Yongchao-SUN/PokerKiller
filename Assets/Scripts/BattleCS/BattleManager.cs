using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class BattleManager : MonoBehaviour
{
    CardLoad CardLoad;
    DeckLoad DeckLoad;
    PokerLoad PokerLoad;
    PlayerLoad PlayerLoad;
    MonsterLoad MonsterLoad;

    public GameObject EffectHand;
    public GameObject PokerHand;
    public GameObject BattleCardPrefab;
    public GameObject PokerPrefab;
    public GameObject PlayerPrefab;
    public GameObject MonsterPrefab_A;
    public GameObject MonsterPrefab_B;
    public GameObject MonsterPrefab_C;
    public GameObject PlayerPool;
    public GameObject MonsterPool;
    public GameObject NewTurnPopupPrefab;
    public GameObject ProduceButton;
    
    public int drawCardAmount = 3;
    public int drawPokerAmount = 6;
    public float popTime = 0.5f;
    public static string monsterType;
    public int energyChargeAmount;
    public List<GameObject> drawCardList = new List<GameObject>();
    public List<GameObject> drawPokerList = new List<GameObject>();
    public List<int> pokerDamageComponent = new List<int>();
    public List<int> pokerShieldComponent = new List<int>();
    public List<int> pokerHealthComponent = new List<int>();
    public GameObject[] childObjects;

    public int playerShield = 0;
    public int monsterShield = 0;
    public static int monsterHp = 50;

    public bool ifPlayerShieldHealthDeal = false;
    public static bool ifMonsterShieldHealthDeal = false;
    public bool ifPlayerDamageDeal = false;
    public static bool ifMonsterDamageDeal = false;
    public bool ifPokerSelectedLegal = false;

    // Start is called before the first frame update
    void Start()
    {
        CardLoad = GetComponent<CardLoad>();
        DeckLoad = GetComponent<DeckLoad>();
        PokerLoad = GetComponent<PokerLoad>();
        PlayerLoad = GetComponent<PlayerLoad>();
        MonsterLoad = GetComponent<MonsterLoad>();
        childObjects = new GameObject[transform.childCount];
        CardLoad.LoadCardData();
        DeckLoad.LoadDeckData();
        PokerLoad.LoadPokerData();
        energyChargeAmount = PlayerLoad.LoadPlayerData("maxEnergy");
        ProduceButton.SetActive(ifPokerSelectedLegal);

        gameStart();
    }

    // Update is called once per frame
    void Update()
    {
        pokerSelectedLegalJudge();

        if (monsterHp <= 0)
        {
            battleWin();
        }

        if (BattleCard.ifBattleCardClicked == true)
        {
            useEffect(BattleCard.lastClickedCardName);
            BattleCard.ifBattleCardClicked = false;
        }
    }

    public void playerHpChange(int changeAmount)
    {
        string filePath = "Assets/Data/playerData.csv";
        var lines = File.ReadAllLines(filePath);

        var columns = lines[1].Split(',');
        if (int.Parse(columns[2]) + changeAmount <= int.Parse(columns[1]))
        {
            columns[2] = (int.Parse(columns[2]) + changeAmount).ToString();
        }
        else
        {
            columns[2] = columns[1];
        }
        lines[1] = string.Join(",", columns);

        File.WriteAllLines(filePath, lines);
    }
    public void monsterHpChange(int changeAmount)
    {
        if (monsterHp + changeAmount <= int.Parse(MonsterLoad.LoadMonsterData(monsterType, "maxHp")))
        {
            monsterHp += changeAmount;
        }
        else
        {
            monsterHp = int.Parse(MonsterLoad.LoadMonsterData(monsterType, "maxHp"));
        }
    }

    public void monsterBehave()
    {
        ifMonsterShieldHealthDeal = false;
        ifMonsterDamageDeal = false;

        string monsterBehaviorType = MonsterBehavior.monsterBehaviorType(MonsterLoad.LoadMonsterData(monsterType, "behavior"));

        if (monsterBehaviorType == "Atk")
        {
            ifMonsterShieldHealthDeal = true;
        }
        else if (monsterBehaviorType == "Def")
        {
            ifMonsterDamageDeal = true;
        }
    }

    public void playerBuffDeal()
    {

    }
    public void MonsterBuffDeal()
    {

    }
    public void playerShieldHealthDeal()
    {
        playerShield = 0;
        int TotalShield = 0;
        int TotalHealth = 0;
        foreach (var shield in pokerShieldComponent)
        {
            TotalShield += shield;
        }
        foreach (var health in pokerHealthComponent)
        {
            TotalHealth += health;
        }
        playerShield += TotalShield;
        playerHpChange(TotalHealth);
    }
    public void monsterShieldHealthDeal()
    {
        monsterShield = 0;

        if (ifMonsterShieldHealthDeal == true)
        {
            monsterShield = int.Parse(MonsterLoad.LoadMonsterData(monsterType, "def"));
        }
    }
    public void playerDamageDeal()
    {
        int TotalDamage = 0;
        foreach (var damage in pokerDamageComponent)
        {
            TotalDamage += damage;
        }
        if (monsterShield <= TotalDamage)
        {
            monsterHpChange(monsterShield - TotalDamage);
        }
        else 
        {
            monsterShield -= TotalDamage;
        }
    }
    public void monsterDamageDeal()
    {
        if (ifMonsterDamageDeal == true)
        {
            int monsterDamage = int.Parse(MonsterLoad.LoadMonsterData(monsterType, "atk"));

            if (playerShield <= monsterDamage)
            {
                playerHpChange(playerShield - monsterDamage);
            }
            else 
            {
                playerShield -= monsterDamage;
            }
        }
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
        foreach (var poker in drawPokerList)
        {
            Destroy(poker);
        }
        drawPokerList.Clear();
    }
    public void drawCard(int drawCardAmount)
    {
        if (DeckLoad.cardListOfDeck.Count < drawCardAmount)
        {
            DeckLoad.LoadDeckData();
        }

        for (int i = 0; i < drawCardAmount; i++)
        {
            GameObject newCard = GameObject.Instantiate(BattleCardPrefab, EffectHand.transform);
            newCard.GetComponent<CardDisplay>().card = DeckLoad.RandomDrawCard();
            
            drawCardList.Add(newCard);
        }
    }
    public void drawPoker(int drawPokerAmount)
    {
        if (PokerLoad.pokerList.Count < drawPokerAmount)
        {
            PokerLoad.LoadPokerData();
        }

        for (int i = 0; i < drawPokerAmount; i++)
        {
            GameObject newPoker = GameObject.Instantiate(PokerPrefab, PokerHand.transform);
            newPoker.GetComponent<PokerDisplay>().poker = PokerLoad.RandomDrawPoker();
            
            drawPokerList.Add(newPoker);
        }
    }
    public void energyCharge(int energyChargeAmount)
    {
        string filePath = "Assets/Data/playerData.csv";
        var lines = File.ReadAllLines(filePath);

        var columns = lines[1].Split(',');
        columns[5] = (int.Parse(columns[5]) + energyChargeAmount).ToString();
        lines[1] = string.Join(",", columns);

        File.WriteAllLines(filePath, lines);
    }

    public void PokerProduce()
    {
        pokerDamageComponent.Add(PokerBehavior.PokerDamageStat());
        pokerShieldComponent.Add(PokerBehavior.PokerShieldStat());
        pokerHealthComponent.Add(PokerBehavior.PokerHealthStat());
        foreach (var GameObject in PokerBehavior.SelectedObjectList)
        {
            Destroy(GameObject);
        }
        PokerBehavior.SelectedPokerList.Clear();
        PokerBehavior.SelectedObjectList.Clear();
    }
    public void turnEndButton()
    {
        //playerBuffDeal();
        //MonsterBuffDeal();
        playerShieldHealthDeal();
        monsterShieldHealthDeal();
        playerDamageDeal();
        monsterDamageDeal();
        //newTurnAlert();
        throwPoker();
        throwHand();
        drawPoker(drawPokerAmount);
        drawCard(drawCardAmount);
        energyCharge(energyChargeAmount);
        monsterBehave();
    }

    public void playerCreate()
    {
        GameObject player = GameObject.Instantiate(PlayerPrefab, PlayerPool.transform);
    }
    public void monsterCreate()
    {
        if (Random.value < 1f / 3f)
        {
            GameObject monster = GameObject.Instantiate(MonsterPrefab_A, MonsterPool.transform);
            monsterType = "Monster_A";
        }
        else if (Random.value < 2f / 3f)
        {
            GameObject monster = GameObject.Instantiate(MonsterPrefab_B, MonsterPool.transform);
            monsterType = "Monster_B";
        }
        else
        {
            GameObject monster = GameObject.Instantiate(MonsterPrefab_C, MonsterPool.transform);
            monsterType = "Monster_C";
        }
        monsterHp = int.Parse(MonsterLoad.LoadMonsterData(monsterType, "maxHp"));
    }

    public void gameStart()
    {
        string filePath = "Assets/Data/playerData.csv";
        var lines = File.ReadAllLines(filePath);

        var columns = lines[1].Split(',');
        columns[5] = columns[4];
        lines[1] = string.Join(",", columns);

        File.WriteAllLines(filePath, lines);
        playerCreate();
        monsterCreate();
        drawCard(drawCardAmount);
        drawPoker(drawPokerAmount);
        monsterBehave();
    }

    public void battleWin()
    {
        SceneLoadManager.LoadSceneByName("BattleReward");
    }

    public void battleLose()
    {
        
    }

    public void pokerSelectedLegalJudge()
    {
        if (PokerBehavior.SelectedPokerList.Count == 0)
        {
            ifPokerSelectedLegal = false;
        }
        else if (PokerBehavior.SelectedPokerList.Count == 1)
        {
            ifPokerSelectedLegal = true;
        }
        else if (PokerBehavior.SelectedPokerList.Count == 2)
        {
            if (PokerBehavior.SelectedPokerList[0].pokerNumber == PokerBehavior.SelectedPokerList[1].pokerNumber)
            {
                ifPokerSelectedLegal = true;
            }
            else
            {
                ifPokerSelectedLegal = false;
            }
        }
        else if (PokerBehavior.SelectedPokerList.Count == 3)
        {
            if (PokerBehavior.SelectedPokerList[0].pokerNumber == PokerBehavior.SelectedPokerList[1].pokerNumber && PokerBehavior.SelectedPokerList[0].pokerNumber == PokerBehavior.SelectedPokerList[2].pokerNumber)
            {
                ifPokerSelectedLegal = true;
            }
            else
            {
                ifPokerSelectedLegal = false;
            }
        }
        else if (PokerBehavior.SelectedPokerList.Count == 4)
        {
            if (PokerBehavior.SelectedPokerList[0].pokerNumber == PokerBehavior.SelectedPokerList[1].pokerNumber && PokerBehavior.SelectedPokerList[0].pokerNumber == PokerBehavior.SelectedPokerList[2].pokerNumber && PokerBehavior.SelectedPokerList[0].pokerNumber == PokerBehavior.SelectedPokerList[3].pokerNumber)
            {
                ifPokerSelectedLegal = true;
            }
            else if ((PokerBehavior.SelectedPokerList[0].pokerNumber == PokerBehavior.SelectedPokerList[1].pokerNumber && PokerBehavior.SelectedPokerList[0].pokerNumber == PokerBehavior.SelectedPokerList[2].pokerNumber) || (PokerBehavior.SelectedPokerList[3].pokerNumber == PokerBehavior.SelectedPokerList[1].pokerNumber && PokerBehavior.SelectedPokerList[3].pokerNumber == PokerBehavior.SelectedPokerList[2].pokerNumber))
            {
                ifPokerSelectedLegal = true;
            }
            else
            {
                ifPokerSelectedLegal = false;
            }
        }
        else if (PokerBehavior.SelectedPokerList.Count == 5)
        {
            for (int i = 0; i < 5; i++)
            {
                if (PokerBehavior.SelectedPokerList[i].pokerNumber == PokerBehavior.SelectedPokerList[i + 1].pokerNumber)
                {
                    ifPokerSelectedLegal = true;
                }
                else
                {
                    ifPokerSelectedLegal = false;
                    break;
                }
            }
            if ((PokerBehavior.SelectedPokerList[0].pokerNumber == PokerBehavior.SelectedPokerList[1].pokerNumber && PokerBehavior.SelectedPokerList[0].pokerNumber == PokerBehavior.SelectedPokerList[2].pokerNumber) || (PokerBehavior.SelectedPokerList[4].pokerNumber == PokerBehavior.SelectedPokerList[2].pokerNumber && PokerBehavior.SelectedPokerList[4].pokerNumber == PokerBehavior.SelectedPokerList[3].pokerNumber))
            {
                ifPokerSelectedLegal = true;
            }
            else
            {
                ifPokerSelectedLegal = false;
            }
        }
        else if (PokerBehavior.SelectedPokerList.Count == 6)
        {
            for (int i = 0; i < 6; i++)
            {
                if (PokerBehavior.SelectedPokerList[i].pokerNumber == PokerBehavior.SelectedPokerList[i + 1].pokerNumber)
                {
                    ifPokerSelectedLegal = true;
                }
                else
                {
                    ifPokerSelectedLegal = false;
                    break;
                }
            }
            if(PokerBehavior.SelectedPokerList[0].pokerNumber == PokerBehavior.SelectedPokerList[1].pokerNumber && PokerBehavior.SelectedPokerList[2].pokerNumber == PokerBehavior.SelectedPokerList[3].pokerNumber && PokerBehavior.SelectedPokerList[4].pokerNumber == PokerBehavior.SelectedPokerList[5].pokerNumber)
            {
                ifPokerSelectedLegal = true;
            }
            else
            {
                ifPokerSelectedLegal = false;
            }
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                if (PokerBehavior.SelectedPokerList[i] == PokerBehavior.SelectedPokerList[i + 1])
                {
                    ifPokerSelectedLegal = true;
                }
                else
                {
                    ifPokerSelectedLegal = false;
                    break;
                }
            }
        }

        ProduceButton.SetActive(ifPokerSelectedLegal);
    }

    public void useEffect(string cardName)
    {
        if (cardName == "Poker Tricks")
        {
            drawPoker(2);
            energyCharge(-1);
        }
        else if (cardName == "Revitalize Spirit")
        {
            energyCharge(2);
        }
        else if (cardName == "More is better")
        {
            drawCard(2);
            energyCharge(-1);
        }
    }
}
