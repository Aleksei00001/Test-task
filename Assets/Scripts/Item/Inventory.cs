using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject imageInventory;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject playerControlUI;
    [SerializeField] private PresItemMenu presItemMenu;
    [SerializeField] private AllItems allItems;

    [SerializeField] private Image shotButtenImage;

    [SerializeField] private List<Item> items;
    [SerializeField] private Slot slot;
    [SerializeField] private List<Slot> slots;

    [SerializeField] private Weapon m_Weapon;
    public Weapon weapon => m_Weapon;

    public Item GetItemsID(int ID)
    {
        return items[ID];
    }

    public int GetSize()
    {
        return items.Count;
    }

    private void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                slots.Add(Instantiate<Slot>(slot));
                slots[i * 5 + j].SetPresItemMenu(presItemMenu);
                slots[i * 5 + j].transform.SetParent(imageInventory.transform);
                slots[i * 5 + j].transform.position = new Vector3(j * 270 + 2380, -i * 270 + 1620, 0);
            }
        }
        UpdateSlots();
        OpenOrCloseInventory(false);
    }

    public void UpdateSlots()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (items.Count > i)
            {
                slots[i].SetItem(items[i]);
            }
            else
            {
                slots[i].SetVoid();
            }
        }
    }

    public void OpenOrCloseInventory(bool openOrClose)
    {
        inventoryUI.SetActive(openOrClose);
        playerControlUI.SetActive(!openOrClose);
        UpdateSlots();
        presItemMenu.SetItem(null);
    }

    public void AddItem(Item newItem, int count)
    {
        Item newItemInInventory = Item.CreateInstance<Item>();
        newItemInInventory.SetItem(newItem);
        if (newItemInInventory.GetIsSingle() == true)
        {
            for (int i = 0; i < count; i++)
            {
                items.Add(newItemInInventory);
                items[items.Count - 1].AddCount(1);
            }
        }
        else
        {
            bool isFind = false;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].GetName() == newItemInInventory.GetName())
                {
                    items[i].AddCount(count);
                    isFind = true;
                    break;
                }
            }
            if (isFind == false)
            {
                items.Add(newItemInInventory);
                items[items.Count - 1].AddCount(count);
            }
        }
    }

    public void DeliteAllItemInSlot(Item deliteItem)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetName() == deliteItem.GetName())
            {
                items.RemoveAt(i);
                UpdateSlots();
                break;
            }
        }
    }

    public void DeliteAllItem()
    {
        while (items.Count > 0)
        {
            items.Remove(items[0]);
        }
    }

    public void SelectWeapon(Item newItem)
    {
        if (newItem.GetWeapon() != null)
        {
            m_Weapon = newItem.GetWeapon();
            shotButtenImage.sprite = m_Weapon.sprite;
        }
    }

    public Item FindItem(Item findItem)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetName() == findItem.GetName())
            {
                return items[i];
            }
        }
        return null;
    }

    public void ReduceItemCount(Item findItem, int count)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetName() == findItem.GetName())
            {
                items[i].ReduceCount(count);
                if (items[i].GetCount() <= 0)
                {
                    DeliteAllItemInSlot(items[i]);
                }
                break;
            }
        }
    }

    public void LoadDate(Save.ItemsSeveDate save)
    {
        AddItem(allItems.FindItemInAllItem(save.name), save.count);
    }
}
