using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SortByNameLength : ISortStrategy
{
    public List<Item> Sort(List<Item> items)
    {
        return items.OrderBy(item => item.Name.Length).ToList();
    }
}
