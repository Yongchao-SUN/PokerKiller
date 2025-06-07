public class Card
{
    public int Id;
    public string cardName;
    public string cardDescription;
    public string cardEnergyRequired;
    public string cardObject;
    public Card(int _id, string _cardName, string _cardDescription, string _cardEnergyRequired, string _cardObject)
    {
        this.Id = _id;
        this.cardName = _cardName;
        this.cardDescription = _cardDescription;
        this.cardEnergyRequired = _cardEnergyRequired;
        this.cardObject = _cardObject;
    }
}

