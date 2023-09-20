using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllItems : MonoBehaviour
{
    [SerializeField] private List<Item> allItems;

    public Item FindItemInAllItem(string findName)
    {
        for (int i = 0; i < allItems.Count; i++)
        {
            if (allItems[i].GetName() == findName)
            {
                return allItems[i];
            }
        }
        return null;
    }
}
