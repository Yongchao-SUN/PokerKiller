using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerData : MonoBehaviour
{
    public CardReloud CardReloud;
    public int playerCoins;
    public int[] playerDeck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPlayerData()
    {

    }

    public void SavePlayerData()
    {
        string path = Application.dataPath + "/Datas/playerdata.csv";

        List<string> datas = new List<string>();
        datas.Add("coins," + playerCoins.ToString());
        for (int i = 0; i < playerDeck.Length; i++)
        {
            if (playerDeck[i] != 0){
                datas.Add("card," + i.ToString() + "," + playerDeck[i].ToString())  
            }
        }

        File.WriteAllLines(path, datas);
    }
}
