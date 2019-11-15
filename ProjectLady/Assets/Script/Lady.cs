using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lady : MonoBehaviour
{
    public Vector3 _vec;
    public float _speed;

    private EventManager _eventManager;
    //public bool _goalMovePoint;

    private void Awake()
    {
        _eventManager = FindObjectOfType<EventManager>();    
    }

    public void LadyMove(Vector3 _targetPosition)
    {      
        transform.position = 
            Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (transform.position == _targetPosition)return;
    }
}
