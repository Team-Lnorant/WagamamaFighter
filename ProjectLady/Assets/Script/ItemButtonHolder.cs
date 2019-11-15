using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemButtonHolder : MonoBehaviour
{
    public ItemManager.ITEM item = ItemManager.ITEM.NULL;

    public ItemUnityEvent useItem = new ItemUnityEvent();

    private CanvasGroup parentCanvas;

    public class ItemUnityEvent: UnityEvent<ItemManager.ITEM>
    {

    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(PushButton);
        parentCanvas = transform.parent.GetComponent<CanvasGroup>();
    }

    public void PushButton()
    {
        useItem.Invoke(item);
        parentCanvas.alpha = 0.0f;
        parentCanvas.interactable = false;
    }
}
