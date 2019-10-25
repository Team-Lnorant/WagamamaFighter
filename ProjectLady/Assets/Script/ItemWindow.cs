using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ItemWindow : MonoBehaviour
{
    public List<ItemInfo> itemInfos;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    [System.Serializable]
    public class ItemInfo
    {
        public ItemManager.ITEM item;
        public Sprite sprite;
    }

    //インベントリにアイテムを表示
    public void SetItemWindow(int num, ItemManager.ITEM flag)
    {
        switch (num)
        {
            case 0:
                button1.GetComponent<Image>().sprite = ConvertItemToSprite(flag);
                button1.GetComponent<ItemButtonHolder>().item = flag;
                break;
            case 1:
                button2.GetComponent<Image>().sprite = ConvertItemToSprite(flag);
                button2.GetComponent<ItemButtonHolder>().item = flag;

                break;
            case 2:
                button3.GetComponent<Image>().sprite = ConvertItemToSprite(flag);
                button3.GetComponent<ItemButtonHolder>().item = flag;

                break;
            case 3:
                button4.GetComponent<Image>().sprite = ConvertItemToSprite(flag);
                button4.GetComponent<ItemButtonHolder>().item = flag;

                break;

        }
    }

    public void AddEventUseItem(UnityAction<ItemManager.ITEM> unityEvent)
    {
        button1.GetComponent<ItemButtonHolder>().useItem.AddListener(unityEvent);
        button2.GetComponent<ItemButtonHolder>().useItem.AddListener(unityEvent);
        button3.GetComponent<ItemButtonHolder>().useItem.AddListener(unityEvent);
        button4.GetComponent<ItemButtonHolder>().useItem.AddListener(unityEvent);
    }

    private Sprite ConvertItemToSprite(ItemManager.ITEM item)
    {
        Sprite ret = null;
        foreach(ItemInfo ii in itemInfos)
        {
            if(ii.item == item)
            {
                ret = ii.sprite;
            }
        }
        return ret;
    }
}
