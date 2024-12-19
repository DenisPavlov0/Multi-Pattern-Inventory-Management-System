using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SortByName : ISortStrategy
{
    public List<Item> Sort(List<Item> items)
    {
        return items.OrderBy(item => item.Name).ToList();
    }
}
