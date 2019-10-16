using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private GameObject Player;
   
    void Start()
    {
        this.Player = GameObject.Find("Player");
}

    void Update()
    {
       Camera();
       CameraRestriction();
    }

    private void Camera()
    {
        //キャラにカメラの追従処理
        Vector3 PlayerPos = this.Player.transform.position;
        transform.position = new Vector3(PlayerPos.x, PlayerPos.y, -10);
    }
    private void CameraRestriction() { 
        //画面外を映さない為の処理
        if (transform.position.x < 1)
            transform.position = new Vector3(1 , 0, -10);

        if (transform.position.x >= 180)
            transform.position = new Vector3(180, 0, -10);

    }
}


