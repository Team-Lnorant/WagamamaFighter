using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemButtonHolder : MonoBehaviour
{
    public ItemManager.ITEM item = ItemManager.ITEM.NULL;


    public ItemUnityEvent useItem = new ItemUnityEvent();

    public class ItemUnityEvent: UnityEvent<ItemManager.ITEM>
    {

    }

    public void PushButton()
    {
        useItem.Invoke(item);
    }
}
