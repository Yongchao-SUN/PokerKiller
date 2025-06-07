using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BattleCard : MonoBehaviour, IPointerDownHandler
{
    public GameObject player;
    public GameObject monster;
    public GameObject poker;
    public GameObject ArrowPrefab;
    public GameObject battleCard;
    private GameObject arrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            DestroyArrow();
        }
    }

    public void CreatArrow(Transform _battleCard, GameObject _prefab)
    {
        DestroyArrow();
        arrow = GameObject.Instantiate(_prefab, _battleCard);
        arrow.GetComponent<Arrow>().SetStartPoint(new Vector2(_battleCard.position.x, _battleCard.position.y));
    }
    public void DestroyArrow()
    {
        Destroy(arrow);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        CreatArrow(battleCard.transform, ArrowPrefab);
    }
}