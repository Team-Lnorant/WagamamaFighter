using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDisplay : MonoBehaviour
{
    public CanvasGroup Canvas;
    public Button firstSelectButton;
    private EventSystem eventSystem;

    private void Awake()
    {
        eventSystem = FindObjectOfType<EventSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Canvas.alpha = 0;
        Canvas.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)　//Itemのタグがついてるオブジェクトかを認識
        {
            eventSystem.SetSelectedGameObject(firstSelectButton.gameObject);
            Canvas.alpha = 1.0f;
            Canvas.interactable = true;

        }
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "Inventry")　//Itemのタグがついてるオブジェクトかを認識
    //    {
    //        Canvas.SetActive(true);
    //    }
    //}
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)　//Itemのタグがついてるオブジェクトかを認識
        {
            Canvas.alpha = 0.0f;
            Canvas.interactable = false;

        }
    }
}
