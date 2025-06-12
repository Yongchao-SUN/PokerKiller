using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ProduceButton : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        BattleManager.pokerDamageComponent.Add(PokerBehavior.PokerDamageStat());
        BattleManager.pokerShieldComponent.Add(PokerBehavior.PokerShieldStat());
        BattleManager.pokerHealthComponent.Add(PokerBehavior.PokerHealthStat());
        foreach (var GameObject in PokerBehavior.SelectedObjectList)
        {
            Destroy(GameObject);
        }
        PokerBehavior.SelectedPokerList.Clear();
        PokerBehavior.SelectedObjectList.Clear();
    }
}
