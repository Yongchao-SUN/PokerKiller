using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRewardSceneLoader : MonoBehaviour
{
    CardLoad CardLoad;

    public GameObject CardPool;
    public GameObject CardRewardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        CardLoad = GetComponent<CardLoad>();
        CardLoad.LoadCardData();

        for (int i = 0; i < 3; i++)
        {
            GameObject newCard = GameObject.Instantiate(CardRewardPrefab, CardPool.transform);
            newCard.GetComponent<CardDisplay>().card = CardLoad.RandomCard();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
