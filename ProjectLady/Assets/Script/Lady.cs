﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lady : MonoBehaviour
{
    public Vector3 _vec;
    public float _speed;


    public void LadyMove()
    {
        _vec = Vector3.zero;
        _vec.x += _speed * Time.deltaTime;
        transform.position += _vec;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "TrafficLightsQuestion")
        {
            
        }
    }
}