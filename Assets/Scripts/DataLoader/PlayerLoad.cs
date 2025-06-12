using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerLoad : MonoBehaviour
{
    public static List<int> playerDataList = new List<int>();

    public TextAsset playerData;

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
                for (int i = 0; i < rowArray.Length - 2; i++)
                {
                    playerDataList.Add(int.Parse(rowArray[i + 1]));
                }
            }
        }
    }
}
