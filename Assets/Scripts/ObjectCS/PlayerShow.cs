using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShow : MonoBehaviour
{
    public float targetLength;
    public float changeSpeed = 1.0f;
    public GameObject HpLine;
    public Text HpText;

    private Vector3 originalScale;

    PlayerLoad PlayerLoad;

    // Start is called before the first frame update
    void Start()
    {
        PlayerLoad = GetComponent<PlayerLoad>();
        originalScale = HpLine.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        HpShow();
    }

    public void HpShow()
    {
        targetLength = PlayerLoad.playerDataList[1] / PlayerLoad.playerDataList[0];

        float newX = Mathf.Lerp(HpLine.transform.localScale.x, targetLength, changeSpeed * Time.deltaTime);
        HpLine.transform.localScale = new Vector3(newX, originalScale.y, originalScale.z);

        HpText.text = PlayerLoad.playerDataList[1] + " / " + PlayerLoad.playerDataList[0];
    }
}
