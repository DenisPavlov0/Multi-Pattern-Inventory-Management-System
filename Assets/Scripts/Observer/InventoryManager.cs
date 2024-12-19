using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    // Список предметов
    private List<Item> _items = new List<Item>();
    private const int MaxInventorySize = 28;

    // Событие для уведомления об изменении инвентаря
    public event Action<List<Item>> OnInventoryChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Добавить предмет
    public void AddItem(Item item)
    {
        if (_items.Count >= MaxInventorySize) return;
        Debug.Log($"Item added: {item.Name}");
        _items.Add(item);
        NotifyObservers();
    }

    // Удалить предмет
    public void RemoveItem(Item item)
    {
        Debug.Log($"Item removed: {item.Name}");
        _items.Remove(item);
        NotifyObservers();
    }

    // Получить копию списка предметов
    public List<Item> GetItems()
    {
        return new List<Item>(_items);
    }

    // Уведомить подписчиков об изменении инвентаря
    private void NotifyObservers()
    {
        if (OnInventoryChanged != null)
        {
            OnInventoryChanged.Invoke(new List<Item>(_items));
        }
        else
        {
            Debug.LogWarning("No observers subscribed to OnInventoryChanged!");
        }
    }
    
    public void ReplaceItems(List<Item> newItems)
    {
        _items = new List<Item>(newItems);
        NotifyObservers();
    }
    public int GetRemainingSpace()
    {
        return MaxInventorySize - _items.Count;
    }
}