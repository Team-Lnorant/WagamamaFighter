using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkEvent : EventManager
{
    private Lady _lady;
    private Icon _icon;
    private GameControl _control;
    private WalkEvent _walk;
    private bool _flag;

    private void Awake()
    {
        _lady = FindObjectOfType<Lady>();
        _icon = FindObjectOfType<Icon>();
        _control = FindObjectOfType<GameControl>();
        _walk = FindObjectOfType<WalkEvent>();
    }

    public override void StartEvent()
    {
        //ドリンクアイコン表示
        _icon.SetIconSprit(Icon.EventIcon.THIRSTY);
        _icon.IconTrigger(true);
        _currentTransNum = 0;
        _flag = false;
    }

    public override void UpdateEvent()
    {
        if (_flag)
        {
            _lady.LadyMove(_trans[_currentTransNum].position);
            if (_trans[_currentTransNum].position == _lady.transform.position)
                _currentTransNum++;
        }
    }

    public override void EndEvent()
    {
        _icon.IconTrigger(false);
    }

    public override void UseItem(ItemManager.ITEM item)
    {
        switch (item)
        {
            case ItemManager.ITEM.JUICE:
                _flag = true;
                break;

            default:
                break;     
        }
    }
}
