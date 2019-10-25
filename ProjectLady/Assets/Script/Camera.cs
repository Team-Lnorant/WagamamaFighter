using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private Player _player;

    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    void Update()
    {
        Vector3 _playerPos = this._player.transform.position;
        transform.position = new Vector3(
            _playerPos.x, _playerPos.y, transform.position.z);
    }
}
