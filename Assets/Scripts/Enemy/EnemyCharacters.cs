using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyCharacters : ScriptableObject
{
    [SerializeField] private float m_MaxHP;
    public float maxHP => m_MaxHP;

    [SerializeField] private float m_Spead;
    public float spead => m_Spead;

    [SerializeField] private float m_DistanceAggression;
    public float distanceAgression => m_DistanceAggression;

    [SerializeField] private float m_AttackSpead;
    public float attackSpead => m_AttackSpead;

    [SerializeField] private float m_Damage;
    public float damage => m_Damage;
    [SerializeField] private float m_Size;
    public float size => m_Size;
}
