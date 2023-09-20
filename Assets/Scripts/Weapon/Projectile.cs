using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Move move;
    [SerializeField] private GameObject target;
    [SerializeField] private float spead;
    [SerializeField] private float damage;


    private void Update()
    {
        if (target == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            float z = Quaternion.LookRotation(target.transform.position - this.transform.position).eulerAngles.x;
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, z + 90);
            move.MoveTarget(target, spead, this.gameObject);
            if (Vector3.Magnitude(target.transform.position - this.transform.position) <= spead * Time.deltaTime)
            {
                Destroy(this.gameObject);
                target.GetComponent<Destructible>().TakeDamage(1);
            }
        }   
    }

    public void SetTarget(GameObject newTarget)
    {
        target = newTarget;
    }

    public void SetSpead(float newSpead)
    {
        spead = newSpead;
    }

    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }
}
