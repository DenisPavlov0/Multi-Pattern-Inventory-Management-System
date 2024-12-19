 using System;
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventoryManager inventoryManager;
    [SerializeField] private Transform inventoryPanel;
    [SerializeField] private GameObject itemUIPrefab;

    private void Awake()
    {
        if (inventoryManager != null)
        {
            inventoryManager.OnInventoryChanged += UpdateInventoryUI;
        }
        else
        {
            Debug.Log("inventoryManager null");
        }
       
    }

    private void UpdateInventoryUI(List<Item> items)
    {
        foreach (Transform child in inventoryPanel)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in items)
        {
            var itemUI = Instantiate(itemUIPrefab, inventoryPanel);
            var itemComponent = itemUI.GetComponent<ItemUI>();
            if (itemComponent != null)
            {
                itemComponent.SetItem(item);
            }
            else
            {
                Debug.LogError("ItemUI component is missing on the prefab!");
            }
        }
    }
    
    private void OnDestroy()
    {
       
        if (inventoryManager != null)
        {
            inventoryManager.OnInventoryChanged -= UpdateInventoryUI;
        }
    }
}
