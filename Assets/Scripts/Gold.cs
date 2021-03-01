using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    private int totalGold;
    private int shopGold = 500;
    private float timeSeconds = 1;
    public Gems gems;
    
    //public delegate int OnGemBought(Gems totalGems);

    
   

    public int TotalGold
    {
        get => totalGold; 
        set => totalGold = value;
    }
    
    IEnumerator PassiveIncome()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSeconds);
            TotalGold++;
        } 
    }

    public void BuyOnClick()
    {
        BuyGem();
    }
    public int BuyGem()
    {
        TotalGold -= gems.gemCost;
        gems.totalGems++;
        BuyGemMessage("You bought gem!");
        return totalGold;

    }

    public static void BuyGemMessage(string message)
    {
        print(message);
    }
    
 
    void Start()
    {
        StartCoroutine(PassiveIncome());
    }
    void Update()
    {
        Debug.Log(totalGold);
    }
}
