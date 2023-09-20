using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField] private DropItem dropItem;
    [SerializeField] private Item m_Item;
    public Item item => m_Item;
    [SerializeField] private int m_Count;
    public int count => m_Count;

    private void OnDestroy()
    {
        DropItem newDropItem = Instantiate<DropItem>(dropItem);
        newDropItem.SetDrop(this);
        newDropItem.transform.position = this.transform.position;
    }
}
