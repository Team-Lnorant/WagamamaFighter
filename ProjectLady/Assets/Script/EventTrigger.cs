using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    GameControl gc;

    private void Awake()
    {
        gc = FindObjectOfType<GameControl>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Lady>() != null)
        {
            gc.ChangeEvent(GetComponent<EventManager>());
        }
    }
}
