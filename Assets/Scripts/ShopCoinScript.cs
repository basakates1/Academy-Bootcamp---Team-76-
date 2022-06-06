using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCoinScript : MonoBehaviour
{
    public int totalCoin;
    public Text coinText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalCoin=PlayerPrefs.GetInt("Coin",0);
        coinText.text=totalCoin.ToString();
    }

    public void Reward50Coins(){

        totalCoin=PlayerPrefs.GetInt("Coin");
        totalCoin=totalCoin+50;
        PlayerPrefs.SetInt("Coin", totalCoin);
    }

}
