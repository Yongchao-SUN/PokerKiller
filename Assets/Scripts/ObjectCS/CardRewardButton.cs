using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardRewardButton : MonoBehaviour, IPointerDownHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        if (SceneLoadManager.previousSceneName == "CardRewardScene")
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.SetActive(false);
        SceneLoadManager.LoadSceneByName("CardReward");
    }
}
