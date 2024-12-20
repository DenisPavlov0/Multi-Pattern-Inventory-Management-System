using UnityEngine;

public class AddItemCommand : ICommand
{
    private InventoryManager _inventoryManager;
    private Item _item;

    public AddItemCommand(InventoryManager inventoryManager, Item item)
    {
        _inventoryManager = inventoryManager;
        _item = item;
    }

    public void Execute()
    {
        _inventoryManager.AddItem(_item);
    }

    public void Undo()
    {
        _inventoryManager.RemoveItem(_item);
    }
}