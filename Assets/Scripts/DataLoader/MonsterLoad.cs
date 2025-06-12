using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLoad : MonoBehaviour
{
    public TextAsset monsterData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string LoadMonsterData(string monsterName, string dataType)
    {
        string monsterMaxHp = "";
        string monsterBehavior = "";
        string monsterAtk = "";
        string monsterDef = "";

        string[] dataRow = monsterData.text.Split('\n');
        foreach (var row in dataRow)
        {
            string[] rowArray = row.Split(',');
            if (rowArray[0] == "#")
            {
                continue;
            }
            else if (rowArray[0] == "##")
            {
                if (rowArray[1] == monsterName)
                {
                    monsterMaxHp = rowArray[2];
                    monsterBehavior = rowArray[3];
                    monsterAtk = rowArray[4];
                    monsterDef = rowArray[5];
                    break;
                }
            }
        }
        
        if (dataType == "maxHp")
        {
            return monsterMaxHp;
        }
        else if (dataType == "behavior")
        {
            return monsterBehavior;
        }
        else if (dataType == "atk")
        {
            return monsterAtk;
        }
        else
        {
            return monsterDef;
        }
    }
}
