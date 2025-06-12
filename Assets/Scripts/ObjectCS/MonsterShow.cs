using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterShow : MonoBehaviour
{
    public float targetLength;
    public float changeSpeed = 1.0f;
    public GameObject HpLine;
    public Text HpText;

    private Vector3 originalScale;

    MonsterLoad MonsterLoad;

    // Start is called before the first frame update
    void Start()
    {
        MonsterLoad = GetComponent<MonsterLoad>();
        originalScale = HpLine.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        HpShow();
    }

    public void HpShow()
    {
        targetLength = BattleManager.monsterHp / int.Parse(MonsterLoad.LoadMonsterData(BattleManager.monsterType, "maxHp"));

        float newX = Mathf.Lerp(HpLine.transform.localScale.x, targetLength, changeSpeed * Time.deltaTime);
        HpLine.transform.localScale = new Vector3(newX, originalScale.y, originalScale.z);

        HpText.text = BattleManager.monsterHp + " / " + MonsterLoad.LoadMonsterData(BattleManager.monsterType, "maxHp");
    }
}
