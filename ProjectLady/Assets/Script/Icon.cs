using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{

    private Vector3 _move;

    public SpriteRenderer _setSprite;
    public Sprite[] _iconTbl;
    public Lady _lady;

    public enum EventIcon{
        QUESTION,
        TIRED,
        THIRSTY,
        EXCLAMATION
    }

    private void Awake()
    {
        _lady = FindObjectOfType<Lady>();
        _setSprite = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        _setSprite.enabled = false;
    }

    void Update()
    {
        IconSetPosition();
    }

    public void IconTrigger(bool trigger)
    {
        _setSprite.enabled = trigger;
    }

    public void SetIconSprit(EventIcon eventIcon)
    {
        _setSprite.sprite = _iconTbl[(int)eventIcon];
    }

    private void IconSetPosition()
    {
        Vector3 vec = _lady.transform.position;
        vec.x = vec.x + 0.3f;
        vec.y = vec.y + 1.0f;
        transform.position = vec;
    }

    private void IconMove ()
    {
        _lady._vec.x += _lady._speed * Time.deltaTime;
        transform.position += _lady._vec;
    }
}

