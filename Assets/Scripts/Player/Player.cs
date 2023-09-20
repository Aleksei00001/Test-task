using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Destructible
{
    [SerializeField] private float m_Spead;
    public float spead => m_Spead;

    private ObjectList m_ObjectList;
    public ObjectList objectList => m_ObjectList;

    private Inventory m_Inventory;
    public Inventory inventory => m_Inventory;


    private void Start()
    {
        m_ObjectList = FindObjectOfType<ObjectList>();
        m_ObjectList.AddPlayer(this);
        m_Inventory = FindObjectOfType<Inventory>();
    }

    private void OnDestroy()
    {
        m_ObjectList.RemovePlayer(this);
    }
}
