using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosswalkEvent : EventManager
{
    private Lady _lady;
    private Icon _icon;
    private GameControl _control;
    private WalkEvent _walk;


    private void Awake()
    {
        _lady = FindObjectOfType<Lady>();
        _icon = FindObjectOfType<Icon>();
        _control = FindObjectOfType<GameControl>();
        _walk = FindObjectOfType<WalkEvent>();
    }

    public override void StartEvent()
    {
        _icon.IconTrigger(true);
    }

    public override void UpdateEvent()
    {
        if(Input.GetKeyDown(KeyCode.A))
        _control.ChangeEvent(_walk);
    }

    public override void UseItem()
    {
        
    }

    public override void EndEvent()
    {
        _icon.IconTrigger(false);
    }
}
