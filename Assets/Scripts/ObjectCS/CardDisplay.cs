using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Text nameText;
    public Text descriptionText;
    public Image backgroundImage;
    public Text energyRequiredText;

    public Card card;

    // Start is called before the first frame update
    void Start()
    {
        ShowCard();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCard()
    {
        nameText.text = card.cardName;
        descriptionText.text = card.cardDescription;
        energyRequiredText.text = card.cardEnergyRequired;
    }
}
