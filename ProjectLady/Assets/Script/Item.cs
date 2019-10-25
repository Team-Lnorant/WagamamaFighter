using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemManager.ITEM _item;
    private SpriteRenderer spriteRenderer;
    private Collider2D collider2;

    public void GetItem()
    {
        Destroy(this.gameObject);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2 = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemNotActive()
    {
        spriteRenderer.enabled = false;
        collider2.enabled = false;
    }
}
