using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEvent : EventManager
{
    private Lady _lady;
    private Icon _icon;


    private void Awake()
    {
        _lady = FindObjectOfType<Lady>();
        _icon = FindObjectOfType<Icon>();
    }

    public override void UpdateEvent()
    {
       
    }
}
