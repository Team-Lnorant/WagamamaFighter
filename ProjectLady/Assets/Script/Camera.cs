using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private GameObject _lady;

    void Start()
    {
        _lady = GameObject.Find("Lady");
    }

    void Update()
    {
        Vector3 _ladyPos = this._lady.transform.position;
        transform.position = new Vector3(
            _ladyPos.x, _ladyPos.y, transform.position.z);
    }
}
