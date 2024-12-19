using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory
{
    public Item CreateItem(ItemData itemData)
    {
        if (itemData == null)
        {
            Debug.LogError("ItemData is null. Cannot create item!");
            return null;
        }
        Debug.Log($"Creating item: {itemData.itemName}");
        return new Item(itemData); // Создаём объект Item на основе ItemData
    }
}
