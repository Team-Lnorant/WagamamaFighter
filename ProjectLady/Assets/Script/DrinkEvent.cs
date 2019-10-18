using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkEvent : EventManager
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
        //ドリンクアイコン表示
        _icon.SetIconSprit(Icon.EventIcon.THIRSTY);
        _icon.IconTrigger(true);
    }
    public override void UpdateEvent()
    {
        //アイテム処理
        //ThirstyEvent();
        if (Input.GetKeyDown(KeyCode.A))
            _control.ChangeEvent(_walk);

    }

    public override void EndEvent()
    {
        _icon.IconTrigger(false);
    }

    void ThirstyEvent()
    {
        //アイテム処理
        switch (0)
        {
            case 0:
                _control.ChangeEvent(_walk);
                break;
            //case 1:
            //    break;
                
        } 
        
    }
}
