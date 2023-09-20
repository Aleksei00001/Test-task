using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public void ShotOnTarget(GameObject target, Weapon weapon)
    {
        if (target != null)
        {
            Projectile newProjectile = Instantiate<Projectile>(weapon.projectile);
            newProjectile.SetSpead(weapon.projectileSpead);
            newProjectile.SetDamage(weapon.damage);
            newProjectile.transform.position = this.transform.position;
            newProjectile.SetTarget(target);
        }
    }
}
