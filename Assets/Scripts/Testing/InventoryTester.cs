using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class InventoryTester : MonoBehaviour
{
    
    [SerializeField] private ItemData[] swords; 
    [SerializeField] private ItemData[] rings;
    [SerializeField] private ItemData[] eats;

    [SerializeField] private Button sortByName;
    [SerializeField] private Button sortByCategory;
    [SerializeField] private Button sortByNameLength;
    
    private ItemFactory _itemFactory;

    private void Start()
    {
        _itemFactory = new ItemFactory();
        sortByName.onClick.AddListener(SortByName);
        sortByCategory.onClick.AddListener(SortByCategory);
        sortByNameLength.onClick.AddListener(SortByNameLength);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AddItem(GetRandomItem(swords));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AddItem(GetRandomItem(rings));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AddItem(GetRandomItem(eats));
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            RemoveItem();
        }
        
    }
    private void AddItem(ItemData itemData)
    {
        if (InventoryManager.Instance.GetRemainingSpace() <= 0)
        {
            Debug.Log("Inventory is full! Cannot add new items.");
            return;
        }
        var newItem = _itemFactory.CreateItem(itemData); // Создаём предмет только если есть место
        InventoryManager.Instance.AddItem(newItem);
    }
    private void RemoveItem()
    {
        var itemList = InventoryManager.Instance.GetItems();
        if (itemList.Count == 0)
        {
            Debug.LogWarning("Inventory is empty. Cannot remove item.");
            return;
        }

        var lastItem = itemList.Last();
        InventoryManager.Instance.RemoveItem(lastItem);
    }
    private void TestSorting(ISortStrategy sortStrategy)
    {
        List<Item> sortedItems = sortStrategy.Sort(InventoryManager.Instance.GetItems());
        Debug.Log($"Sorted items using {sortStrategy.GetType().Name}:");
        InventoryManager.Instance.ReplaceItems(sortedItems);
    }

    private void SortByName()
    {
        TestSorting(new SortByName());
    }
    private void SortByCategory()
    {
        TestSorting(new SortByCategory());
    }
    private void SortByNameLength()
    {
        TestSorting(new SortByNameLength());
    }
    private ItemData GetRandomItem(ItemData[] itemArray)
    {
        int randomIndex = Random.Range(0, itemArray.Length);
        return itemArray[randomIndex];
    }


    private void OnDestroy()
    {
        sortByName.onClick.RemoveListener(SortByName);
        sortByCategory.onClick.RemoveListener(SortByCategory);
        sortByNameLength.onClick.RemoveListener(SortByNameLength);
    }
}
