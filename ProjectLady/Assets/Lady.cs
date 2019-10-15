using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lady : MonoBehaviour
{

    private Vector3 _vec;
    private bool _isWalking;

    public float _speed;

    void Start()
    {
        _isWalking = true;
    }

    void Update()
    {
        if (_isWalking) LadyMove();
        else;
    }

    private void EventQestion()
    {
        var pos = new Vector3(
            (transform.position.x + 0.5f), (transform.position.y + 2.0f), 0.0f);
        var rot = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    }

    private void LadyMove()
    {
        _vec = Vector3.zero;
        _vec.x += _speed * Time.deltaTime;
        transform.position += _vec;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "FlagEvent")
        {
            _isWalking = false;
        }
    }
}
