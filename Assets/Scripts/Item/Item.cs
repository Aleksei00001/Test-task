using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private int count;
    [SerializeField] private Sprite sprite;
    [SerializeField] private bool isSingle;
    [SerializeField] private Weapon weapon;

    public string GetName()
    {
        return name;
    }

    public int GetCount()
    {
        return count;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public bool GetIsSingle()
    {
        return isSingle;
    }

    public Weapon GetWeapon()
    {
        return weapon;
    }

    public void AddCount(int addCount)
    {
        count += addCount;
    }

    public void ReduceCount(int reduceCount)
    {
        count -= reduceCount;
    }

    public void SetItem(Item newItem)
    {
        name = newItem.GetName();
        count = newItem.GetCount();
        sprite = newItem.GetSprite();
        isSingle = newItem.GetIsSingle();
        weapon = newItem.GetWeapon();
    }
}
