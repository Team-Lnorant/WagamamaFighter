using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosswalkEvent : EventManager
{
    private Lady _lady;
    private Icon _icon;
    private GameControl _control;
    private FatigueEvent _fatigue;

    private void Awake()
    {
        _lady = FindObjectOfType<Lady>();
        _icon = FindObjectOfType<Icon>();
        _control = FindObjectOfType<GameControl>();
        _fatigue = FindObjectOfType<FatigueEvent>();
    }

    public override void StartEvent()
    {
        _currentTransNum = 0;
    }

    public override void UpdateEvent()
    {
        _lady.LadyMove(_trans[_currentTransNum].position);
        if (_trans[_currentTransNum].position == _lady.transform.position)
            _icon.IconTrigger(true);
    }

    public override void UseItem(ItemManager.ITEM item)
    {
        if (item == ItemManager.ITEM.FLAG)
        {
            _control.ChangeEvent(_fatigue);
        }
    }

    public override void EndEvent()
    {
        _icon.IconTrigger(false);
    }
}
