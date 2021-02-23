using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    private int totalGold;
    private float timeSeconds = 1;

    public delegate void OnGemBought(Gems gems);

    public OnGemBought onGemBought;

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
            totalGold++;
        } 
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
