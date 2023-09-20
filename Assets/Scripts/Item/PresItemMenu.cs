using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresItemMenu : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    [SerializeField] private Slot slot;

    private Item item;


    public void SetItem(Item newItem)
    {
        item = newItem;
        slot.SetItem(item);
        
    }

    public void DeliteAllItemInSlot()
    {
        inventory.DeliteAllItemInSlot(item);
        slot.SetItem(null);
    }

    public void SelectWeapon()
    {
        inventory.SelectWeapon(item);
    }
}
