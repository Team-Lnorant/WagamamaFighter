using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatigueEvent : EventManager
{
    private Lady _lady;
    private Icon _icon;


    public void Awake()
    {
        _lady = FindObjectOfType<Lady>();
        _icon = FindObjectOfType<Icon>();
    }

    public override void StartEvent()
    {
        _icon.SetIconSprit(Icon.EventIcon.TIRED);
        _icon.IconTrigger(true);
    }
    
    public override void UpdateEvent()
    {
        _lady.LadyMove();
    }

    public override void EndEvent()
    {
        _icon.IconTrigger(false);
    }
}