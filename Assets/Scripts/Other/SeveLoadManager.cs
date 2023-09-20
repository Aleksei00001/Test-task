using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SeveLoadManager : MonoBehaviour
{
    string filePath;

    [SerializeField] private Inventory inventory;

    public List<Item> ItemSaves = new List<Item>();

    private void Start()
    {
        filePath = Application.persistentDataPath + "/save.gamesave";
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Create);

        Save save = new Save();

        ItemSaves.Clear();

        for (int i = 0; i < inventory.GetSize(); i++)
        {
            ItemSaves.Add(inventory.GetItemsID(i));
        }

        save.SaveItemDate(ItemSaves);

        bf.Serialize(fs, save);

        fs.Close();
    }
    public void LoadGame()
    {
        if (!File.Exists(filePath)) return;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(filePath, FileMode.Open);

        Save save = (Save)bf.Deserialize(fs);
        fs.Close();

        inventory.DeliteAllItem();

        int i = 0;
        foreach (var item in save.ItemsSeveData)
        {
            inventory.LoadDate(item);
            i++;
        }
        
        inventory.UpdateSlots();
    }
}
[System.Serializable]
public class Save
{
    [System.Serializable]
    public struct ItemsSeveDate
    {
        public string name;
        public int count;

        public ItemsSeveDate(string name, int count)
        {
            this.name = name;
            this.count = count;
        }
    }

    public List<ItemsSeveDate> ItemsSeveData = new List<ItemsSeveDate>();

    public void SaveItemDate(List<Item> itemDate)
    {
        foreach (var go in itemDate)
        {
            var em = go;

            string name = new string(go.GetName());
            int count = go.GetCount();

            ItemsSeveData.Add(new ItemsSeveDate(name, count));
        }
    }

}


