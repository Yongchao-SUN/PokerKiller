using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string monsterBehaviorKind()
    {
        float monsterAttack = Random.value;
        if (Random.value < 0.5)
        {
            return "Atk";
        }
        else
        {
            return "Def";
        }
    }

    public static int monsterStats(int monsterDiceX, int monsterDiceNumber)
    {
        int monsterStat = 0;
        for (int i = 0; i < monsterDiceNumber; i++)
        {
            int diceResult = Random.Range(1, monsterDiceX + 1);
            monsterStat += diceResult;
        }
        return monsterStat;
    }
}
