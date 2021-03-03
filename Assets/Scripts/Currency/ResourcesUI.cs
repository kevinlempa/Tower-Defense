using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesUI : MonoBehaviour
{
    public Text goldText;
    public Text gemText;
    public Gold gold;
    public Gems gems;
 
    public void DisplayGold()
    {
        goldText.text = "Gold: " + gold.TotalGold.ToString();
    }
    public void DisplayGems()
    {
        gemText.text = "Gems: " + gems.totalGems.ToString();
    }

    
    void Update()
    {
        DisplayGold();
        DisplayGems();
    }
   
   
   
}
