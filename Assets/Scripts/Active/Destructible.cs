using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destructible : MonoBehaviour
{
    [SerializeField] private Image imageHP;

    [SerializeField] private float m_HP;
    public float HP => m_HP;
    [SerializeField] private float m_MaxHP;
    public float maxHP => m_MaxHP;

    

    public void SetMaxHP(float newMaxHP)
    {
        m_MaxHP = newMaxHP;
        SetHP(m_HP);
    }

    public void SetHP(float newHP)
    {
        m_HP = newHP;
        if (m_HP <= 0)
        {
            Destroy(this.gameObject);
        }
        if (m_HP > m_MaxHP)
        {
            m_HP = m_MaxHP;
        }

        imageHP.fillAmount = HP / maxHP;
    }

    public void TakeDamage(float takeDamage)
    {
        SetHP(m_HP - takeDamage);
    }

}
