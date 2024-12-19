using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Text itemNameText; // Текст для названия предмета
    [SerializeField] private Image itemIconImage; // Картинка для иконки предмета

    public void SetItem(Item item)
    {
        itemNameText.text = item.Name;
        itemIconImage.sprite = item.Icon;
    }
}
