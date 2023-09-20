using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private Item item;
    [SerializeField] private int count;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer.sprite = item.GetSprite();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() == true)
        {
            collision.GetComponent<Player>().inventory.AddItem(item, count);
            Destroy(this.gameObject);
        }
    }

    public void SetDrop(Drop newDrop)
    {
        item = newDrop.item;
        count = newDrop.count;
    }
}
