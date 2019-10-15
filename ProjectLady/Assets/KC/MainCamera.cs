using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public GameObject _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.transform.position.x, 5, -10); //キャラにカメラの追従処理

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(0, 5, -10);
        }

        if (transform.position.x >= 18)
        {
            transform.position = new Vector3(18, 5, -10);
        }
    }
}
