using UnityEngine;

public class Item
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Category Category { get; private set; }
    public Sprite Icon { get; private set; }

    public Item(ItemData itemData)
    {
        Name = itemData.itemName;
        Description = itemData.description;
        Category = itemData.category;
        Icon = itemData.icon;
    }
}