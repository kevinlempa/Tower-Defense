using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class Item
{
    public string itemName;
    public Sprite icon;
    public float price = 1f;
}
public class ShopScrollList : MonoBehaviour
{

    public List<Item> itemList;
    public Transform contentPanel;
    public ShopScrollList otherShop;
    public Text myGoldDisplay;
    public ObjectPoolScript buttonObjectPool;
    public float gold = 20f; //OUR GOLD
    
    void Start()
    {
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        myGoldDisplay.text = "Gold: " + gold.ToString();
        RemoveButton();
        AddButtons();
        
    }

    private void AddButtons()
    {
        for (int i = 0; i < itemList.Count; i++)
        {
            Item item = itemList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel, false);

            SampleButton sampleButton = newButton.GetComponent<SampleButton>();
            sampleButton.Setup(item, this);
        }
    }

    private void RemoveButton()
    {
        while (contentPanel.childCount > 0)
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }
    

    public void TryTransferItemTooOtherShop(Item item) //OUR GOLD SET
    {
        if (otherShop.gold >= item.price)
        {
            gold += item.price;
            otherShop.gold -= item.price;
            AddItem(item, otherShop);
            RemoveItem(item, this);
            
            RefreshDisplay();
            otherShop.RefreshDisplay();
        }
            
    }
        

    private void AddItem(Item itemToAdd, ShopScrollList shopList)
    {
        shopList.itemList.Add(itemToAdd);
    }

    private void RemoveItem(Item itemToRemove, ShopScrollList shopList)
    {
        for (int i = shopList.itemList.Count - 1; i >= 0; i--)
        {
            if (shopList.itemList[i] == itemToRemove)
                shopList.itemList.RemoveAt(i);
        }
        
    }
    
    
}
