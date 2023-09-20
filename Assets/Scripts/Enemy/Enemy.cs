using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Destructible
{
    private ObjectList objectList;

    [SerializeField] private EnemyCharacters enemyCharacters;

    [SerializeField] private float spead;
    [SerializeField] private float distanceAgression;
    [SerializeField] private float attackSpead;
    private float attackCooldawn;
    [SerializeField] private float damage;

    [SerializeField] private Move move;

    [SerializeField] private GameObject visual;
    [SerializeField] private float size;

    private void Update()
    {
        Player nearestPlayer = objectList.FindNearestPlayer(this.transform.position);
        if (nearestPlayer != null)
        {
            if (Vector3.Magnitude(nearestPlayer.transform.position - this.transform.position) < distanceAgression)
            {
                if (move.MoveTarget(nearestPlayer.gameObject, spead, this.gameObject) > 0)
                {
                    visual.transform.localScale = new Vector3(size, size, 1);
                }
                else
                {
                    visual.transform.localScale = new Vector3(-size, size, 1);
                }
            }
        }
        attackCooldawn -= Time.deltaTime;
    }

    private void Start()
    {
        objectList = FindObjectOfType<ObjectList>();
        objectList.AddEnemy(this);
        SetEnemyCharacters(enemyCharacters);
    }

    private void OnDestroy()
    {
        objectList.RemoveEnemy(this);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (attackCooldawn <= 0)
        {
            if (collision.transform.GetComponent<Player>() != null)
            {
                collision.transform.GetComponent<Player>().TakeDamage(damage);
                attackCooldawn = attackSpead;
            }
        }
    }

    public void SetEnemyCharacters(EnemyCharacters newEnemyCharacters)
    {
        enemyCharacters = newEnemyCharacters;
        SetMaxHP(newEnemyCharacters.maxHP);
        SetHP(maxHP);
        spead = newEnemyCharacters.spead;
        distanceAgression = newEnemyCharacters.distanceAgression;
        attackSpead = newEnemyCharacters.attackSpead;
        damage = newEnemyCharacters.damage;
        size = newEnemyCharacters.size;
    }


}
