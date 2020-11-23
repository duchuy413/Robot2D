using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadItem : MonoBehaviour
{
    int ITEM_AMOUNT = 9;

    class Item {
        public string itemName;
        public int imageId;

        public Item(string itemName, int imageId)
        {
            this.itemName = itemName;
            this.imageId = imageId;
        }
    }

    List<Item> listItems;
         

    void Start()
    {
        listItems = new List<Item>();
        listItems.Add(new Item("Hạt Táo", 0));
        listItems.Add(new Item("Hạt Đào", 1));
        listItems.Add(new Item("Hạt Lê", 2));
        listItems.Add(new Item("Hạt Dẻ", 3));
        listItems.Add(new Item("Hạt Hướng Dương", 4));
        listItems.Add(new Item("Hạt Kramatus", 5));
        listItems.Add(new Item("Hạt Silvilian", 6));
        listItems.Add(new Item("Hạt Lumi", 7));
        listItems.Add(new Item("Hạt Orenity", 8));

        GameObject itemObj = Resources.Load<GameObject>("ListItem") as GameObject;
        Sprite[] listSprites = Resources.LoadAll<Sprite>("Seed");

        for (int i = 0; i < ITEM_AMOUNT; i++)
        {
            GameObject item = Instantiate(itemObj, transform);
            item.GetComponent<Image>().sprite = listSprites[listItems[i].imageId];
            item.GetComponentInChildren<TextMeshProUGUI>().text = listItems[i].itemName;
        }
    }

}
