using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoad : MonoBehaviour
{
    public TextAsset playerData;
    public int playerMaxHp;
    public int playerHp;
    public int playerCoins;
    public int playerMaxEnergy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public int LoadPlayerData(string dataType)
    {
        string[] dataRow = playerData.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            else if (rowArray[0] == "##")
            {
                playerMaxHp = int.Parse(rowArray[1]);
                playerHp = int.Parse(rowArray[2]);
                playerCoins = int.Parse(rowArray[3]);
                playerMaxEnergy = int.Parse(rowArray[4]);
            }
        }
        
        if (dataType == "maxHp")
        {
            return playerMaxHp;
        }
        else if (dataType == "Hp")
        {
            return playerHp;
        }
        else if (dataType == "coins")
        {
            return playerCoins;
        }
        else if (dataType == "maxEnergy")
        {
            return playerMaxEnergy;
        }
        else
        {
            return 0;
        }
    }
}
