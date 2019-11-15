using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatigueEvent : EventManager
{
    private Lady _lady;
    private Icon _icon;
    private DrinkEvent _drink;
    private GameControl _control;


    public void Awake()
    {
        _lady = FindObjectOfType<Lady>();
        _icon = FindObjectOfType<Icon>();
        _drink = FindObjectOfType<DrinkEvent>();
        _control = FindObjectOfType<GameControl>();
    }

    public override void StartEvent()
    {
        _icon.SetIconSprit(Icon.EventIcon.TIRED);
        _currentTransNum = 0;
    }

    public override void UpdateEvent()
    {
        if(_currentTransNum < _trans.Length)
        {
            _lady.LadyMove(_trans[_currentTransNum].position);
            if (_trans[_currentTransNum].position == _lady.transform.position)
                _currentTransNum++;
        }
        if (_trans[0].position == _lady.transform.position)
        {
            _lady._speed = 1.0f;            
            _icon.IconTrigger(true);
        }
        if (_trans[2].position == _lady.transform.position)
        {
            _control.ChangeEvent(_drink);
        }
    }

    public override void EndEvent()
    {
        _icon.IconTrigger(false);
    }
}