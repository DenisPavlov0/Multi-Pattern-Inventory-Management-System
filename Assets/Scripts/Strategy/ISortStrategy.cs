using System.Collections.Generic;

public interface ISortStrategy
{
    List<Item> Sort(List<Item> items);
}