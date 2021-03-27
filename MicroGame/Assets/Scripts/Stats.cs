using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "CoinCount")
        {
            GetComponent<TextMesh>().text = "Coins : " + GM.coinTotal;
        }

        if (gameObject.name == "Timer")
        {
            GetComponent<TextMesh>().text = "Time : " + Mathf.Round(GM.timeTotal * 100f) / 100f + "s";
        }
        if (gameObject.name == "RunStatus")
        {
            GetComponent<TextMesh>().text = GM.lvlCompStatus; 
        }
    }
}
