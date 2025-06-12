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

    public static string monsterBehaviorType(string MonsterBehavior)
    {
        string[] MonsterBehaviorArray = MonsterBehavior.Split("/");

        if (MonsterBehaviorArray.Length == 1)
        {
            return MonsterBehavior;
        }
        else if (MonsterBehaviorArray.Length == 2)
        {
            if (Random.value < 0.5)
            {
                return MonsterBehaviorArray[0];
            }
            else
            {
                return MonsterBehaviorArray[1];
            }
        }
        else
        {
            if (Random.value < 1f / 3f)
            {
                return MonsterBehaviorArray[0];
            }
            else if (Random.value < 2f / 3f)
            {
                return MonsterBehaviorArray[1];
            }
            else
            {
                return MonsterBehaviorArray[2];
            }
        }
    }
}
