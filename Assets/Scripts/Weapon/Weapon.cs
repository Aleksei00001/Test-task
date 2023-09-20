using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Weapon : ScriptableObject
{
    [SerializeField] private Projectile m_Projectile;
    public Projectile projectile => m_Projectile;

    [SerializeField] private float m_ProjectileSpead;
    public float projectileSpead => m_ProjectileSpead;

    [SerializeField] private float m_ShotRecharge;
    public float shotRecharge => m_ShotRecharge;

    [SerializeField] private Item m_ItemUse;
    public Item itemUse => m_ItemUse;

    [SerializeField] private Sprite m_Sprite;
    public Sprite sprite => m_Sprite;

    [SerializeField] private float m_Damage;
    public float damage => m_Damage;

    [SerializeField] private float m_AttackDistance;
    public float attackDistance => m_AttackDistance;
}
