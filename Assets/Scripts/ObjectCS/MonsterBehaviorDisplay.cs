using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterBehaviorDisplay : MonoBehaviour
{
    MonsterLoad MonsterLoad;

    public Text monsterBehaveText;
    public Text monsterStatText;

    // Start is called before the first frame update
    void Start()
    {
        MonsterLoad = GetComponent<MonsterLoad>();
    }

    // Update is called once per frame
    void Update()
    {
        monsterBehaviorShow();
    }

    public void monsterBehaviorShow()
    {
        if (BattleManager.ifMonsterShieldHealthDeal == true)
        {
            monsterBehaveText.text = "Def";
            monsterStatText.text = MonsterLoad.LoadMonsterData(BattleManager.monsterType, "def");
        }
        else if (BattleManager.ifMonsterDamageDeal == true)
        {
            monsterBehaveText.text = "Atk";
            monsterStatText.text = MonsterLoad.LoadMonsterData(BattleManager.monsterType, "atk");
        }
        else
        {
            monsterBehaveText.text = "";
            monsterStatText.text = "";
        }
    }
}
