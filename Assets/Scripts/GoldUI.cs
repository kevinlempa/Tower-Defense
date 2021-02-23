using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    public Text goldText;
    public Gold gold;
 
    public void DisplayGold()
    {
        goldText.text = "Gold: " + gold.TotalGold.ToString();
    }

    
    void Update()
    {
        DisplayGold();
    }
   
   
   
}
