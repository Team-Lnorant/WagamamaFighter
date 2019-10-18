using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{

    private EventManager _currentEvent;

    private void Awake()
    {
        _currentEvent = FindObjectOfType<WalkEvent>();
    }

    void Start()
    {

    }

    void Update()
    {
        EventUpdate();
    }

    public void UseItemCurrentEvent()
    {
        _currentEvent.UseItem();
    }

    public void ChangeEvent(EventManager eventManager)
    {
        _currentEvent.EndEvent();
        eventManager.StartEvent();
        _currentEvent = eventManager;
    }

    private void EventUpdate()
    {
        if(_currentEvent != null)
        {
            _currentEvent.UpdateEvent();
        }
    }
}
