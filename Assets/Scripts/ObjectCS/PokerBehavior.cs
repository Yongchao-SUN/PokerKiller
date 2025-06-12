using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PokerBehavior : MonoBehaviour, IPointerDownHandler
{
    PokerDisplay PokerDisplay;

    public static int playerDamageMutiple;
    public static int playerShieldMutiple;
    public static int playerHealthMutiple;

    public bool ifPressed = false;

    public static List<Poker> SelectedPokerList = new List<Poker>();
    public static List<GameObject> SelectedObjectList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        PokerDisplay = GetComponent<PokerDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (ifPressed == false)
        {
            PokerDisplay.backGroundImage.color = Color.gray;

            PokerDisplay pokerSc = gameObject.GetComponent<PokerDisplay>();
            Poker poker = pokerSc.poker;

            SelectedObjectList.Add(gameObject);
            SelectedPokerList.Add(poker);

            for (int i = 0; i < SelectedPokerList.Count - 1; i++)
            {
                for (int j = 0; j < SelectedPokerList.Count - i - 1; j++)
                {
                    if (SelectedPokerList[j].pokerNumber > SelectedPokerList[j + 1].pokerNumber)
                    {
                        Poker temp = SelectedPokerList[j];
                        SelectedPokerList[j] = SelectedPokerList[j + 1];
                        SelectedPokerList[j + 1] = temp;
                    }
                }
            }

            ifPressed = true;
        }
        else
        {
            PokerDisplay.backGroundImage.color = Color.white;

            PokerDisplay pokerSc = gameObject.GetComponent<PokerDisplay>();
            Poker poker = pokerSc.poker;

            SelectedObjectList.Remove(gameObject);
            SelectedPokerList.Remove(poker);

            for (int i = 0; i < SelectedPokerList.Count - 1; i++)
            {
                for (int j = 0; j < SelectedPokerList.Count - i - 1; j++)
                {
                    if (SelectedPokerList[j].pokerNumber > SelectedPokerList[j + 1].pokerNumber)
                    {
                        Poker temp = SelectedPokerList[j];
                        SelectedPokerList[j] = SelectedPokerList[j + 1];
                        SelectedPokerList[j + 1] = temp;
                    }
                }
            }

            ifPressed = false;
        }
    }

    public static int PokerDamageStat()
    {
        int damage = 0;
        for (int i = 0; i < SelectedPokerList.Count; i++)
        {
            if (SelectedPokerList[i].pokerSuit == "♠" || SelectedPokerList[i].pokerSuit == "♣")
            {
                playerDamageMutiple = 1;
                break;
            }
            else
            {
                playerDamageMutiple = 0;
            }
        }
        for (int i = 0; i < SelectedPokerList.Count; i++)
        {
            damage += SelectedPokerList[i].pokerNumber;
        }
        return damage * playerDamageMutiple;
    }

    public static int PokerShieldStat()
    {
        int shield = 0;
        for (int i = 0; i < SelectedPokerList.Count; i++)
        {
            if (SelectedPokerList[i].pokerSuit == "♦")
            {
                playerShieldMutiple = 1;
                break;
            }
            else
            {
                playerShieldMutiple = 0;
            }
        }
        for (int i = 0; i < SelectedPokerList.Count; i++)
        {
            shield += SelectedPokerList[i].pokerNumber;
        }
        return shield * playerShieldMutiple;
    }

    public static int PokerHealthStat()
    {
        int health = 0;
        for (int i = 0; i < SelectedPokerList.Count; i++)
        {
            if (SelectedPokerList[i].pokerSuit == "♥")
            {
                playerHealthMutiple = 1;
                break;
            }
            else
            {
                playerHealthMutiple = 0;
            }
        }
        for (int i = 0; i < SelectedPokerList.Count; i++)
        {
            health += SelectedPokerList[i].pokerNumber;
        }
        return health * playerHealthMutiple;
    }
}
