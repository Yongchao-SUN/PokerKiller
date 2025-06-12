using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerLoad : MonoBehaviour
{
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
        int playerMaxHp = 0;
        int playerHp = 0;
        int playerCoins = 0;
        int playerMaxEnergy = 0;
        int playerEnergy = 0;

        string filePath = "Assets/Data/playerData.csv";
        var lines = File.ReadAllLines(filePath);

        var columns = lines[1].Split(',');
        playerMaxHp = int.Parse(columns[1]);
        playerHp = int.Parse(columns[2]);
        playerCoins = int.Parse(columns[3]);
        playerMaxEnergy = int.Parse(columns[4]);
        playerEnergy = int.Parse(columns[5]);
        
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
        else if (dataType == "energy")
        {
            return playerEnergy;
        }
        else
        {
            return 0;
        }
    }
}
