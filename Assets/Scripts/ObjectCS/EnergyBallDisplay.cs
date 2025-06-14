using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBallDisplay : MonoBehaviour
{
    PlayerLoad PlayerLoad;

    public Text EnergyShowText;

    // Start is called before the first frame update
    void Start()
    {
        PlayerLoad = GetComponent<PlayerLoad>();
    }

    // Update is called once per frame
    void Update()
    {
        ShowEnergy();
    }

    public void ShowEnergy()
    {
        string EnergyShow = PlayerLoad.playerDataList[4] + "/" + PlayerLoad.playerDataList[3];
        EnergyShowText.text = EnergyShow;
    }
}
