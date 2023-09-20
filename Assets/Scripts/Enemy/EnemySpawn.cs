using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private EnemyCharacters enemyCharacters;

    private void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            Enemy newEnamy = Instantiate<Enemy>(enemy);
            newEnamy.SetEnemyCharacters(enemyCharacters);
            newEnamy.transform.position = new Vector3(Random.Range(10f, 40f), Random.Range(-5f, 5f));
        }
    }
}
