using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SampleButton : MonoBehaviour
{
    public Button button;
    public Text nameLabel;
    public Text priceLabel;
    public Image iconImage;

    private Item item;
    private ShopScrollList scrolllist;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(Item currentItem, ShopScrollList currentScrollList)
    {
        item = currentItem;
        nameLabel.text = item.itemName;
        priceLabel.text = item.price.ToString();
        iconImage.sprite = item.icon;

        scrolllist = currentScrollList;
    }
    
}