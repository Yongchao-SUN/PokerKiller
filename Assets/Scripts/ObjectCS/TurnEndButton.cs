using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TurnEndButton : MonoBehaviour, IPointerDownHandler
{
    public static bool ifEndTurn = false;
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
        ifEndTurn = true;
    }
}
