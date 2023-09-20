using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] private Item item;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private Image image;

    private PresItemMenu presItemMenu;
    public void SetItem(Item newItem)
    {
        item = newItem;
        UpdateUI();
    }

    public void UpdateUI()
    {
        if (item != null)
        {
            if (item.GetCount() > 1)
            {
                text.text = item.GetCount().ToString();
            }
            else
            {
                text.text = "";
            }
            if (item.GetSprite() == null)
            {
                image.color = new Color32(0, 0, 0, 0);
            }
            else
            {
                image.color = new Color32(255, 255, 255, 255);
                image.sprite = item.GetSprite();
            }
        }
        else
        {
            text.text = "";
            image.color = new Color32(0, 0, 0, 0);
        }
    }

    public void SetVoid()
    {
        item = null;
        UpdateUI();
    }

    public void SetPresItemMenu(PresItemMenu newPresItemMenu)
    {
        presItemMenu = newPresItemMenu;
    }

    public void Select()
    {
        presItemMenu.SetItem(item);
    }
}
