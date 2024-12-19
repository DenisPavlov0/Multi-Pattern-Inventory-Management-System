using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SortByCategory : ISortStrategy
{
    public List<Item> Sort(List<Item> items)
    {
        return items.OrderBy(item => item.Category.ToString()).ToList();
    }
}
