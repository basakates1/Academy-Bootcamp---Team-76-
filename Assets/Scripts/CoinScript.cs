using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public Text coinText;
    public int totalCoin;
    public ScoreScript score;

    void Start()
    {
        totalCoin=PlayerPrefs.GetInt("Coin",0);
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text=totalCoin.ToString();
    }

    public void CoinUpdate(){
        totalCoin=totalCoin+score.coinGained;
        PlayerPrefs.SetInt("Coin",totalCoin);
    }

    public void CoinUpdateX2(){
        totalCoin=totalCoin+(score.coinGained)*2;
        PlayerPrefs.SetInt("Coin",totalCoin);
    }
}
