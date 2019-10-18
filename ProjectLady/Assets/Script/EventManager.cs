﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public virtual void StartEvent() { }
    public virtual void UpdateEvent() { }
    public virtual void EndEvent() { }
    public virtual void UseItem() { }
}
