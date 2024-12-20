using UnityEngine;

public class RemoveItemCommand : ICommand
{
    private InventoryManager _inventoryManager;
    private Item _item;

    public RemoveItemCommand(InventoryManager inventoryManager, Item item)
    {
        _inventoryManager = inventoryManager;
        _item = item;
    }

    public void Execute()
    {
        _inventoryManager.RemoveItem(_item);
    }

    public void Undo()
    {
        _inventoryManager.AddItem(_item);
    }
}