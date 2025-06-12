using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokerDisplay : MonoBehaviour
{
    public Text numberText;
    public Text suitText;
    public Image backGroundImage;

    public Poker poker;

    // Start is called before the first frame update
    void Start()
    {
        ShowPoker();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPoker()
    {
        if (poker.pokerNumber == 1)
        {
            numberText.text = "A";
        }
        else if (poker.pokerNumber == 11)
        {
            numberText.text = "J";
        }
        else if (poker.pokerNumber == 12)
        {
            numberText.text = "Q";
        }
        else if (poker.pokerNumber == 13)
        {
            numberText.text = "K";
        }
        else
        {
            numberText.text = poker.pokerNumber.ToString();
        }
        suitText.text = poker.pokerSuit;
        if (poker.pokerSuit == "♥" || poker.pokerSuit == "♦")
        {
            suitText.color = Color.red;
        }
    }
}
