using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectList : MonoBehaviour
{
    [SerializeField] List<Player> players;
    [SerializeField] List<Enemy> enemys;

    public void AddPlayer(Player player)
    {
        players.Add(player);
    }

    public void RemovePlayer(Player player)
    {
        players.Remove(player);
    }

    public void AddEnemy(Enemy enemy)
    {
        enemys.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemys.Remove(enemy);
    }

    public Enemy FindNearestEnemy(Vector3 startPoint)
    {
        if (enemys.Count > 0)
        {
            Enemy nearestEnemy = enemys[0];
            for (int i = 0; i < enemys.Count; i++)
            {
                if (Vector3.Magnitude(startPoint - nearestEnemy.transform.position) > Vector3.Magnitude(startPoint - enemys[i].transform.position))
                {
                    nearestEnemy = enemys[i];
                }
            }
            return nearestEnemy;
        }
        else
        {
            return null;
        }
    }

    public Player FindNearestPlayer(Vector3 startPoint)
    {
        if (players.Count > 0)
        {
            Player nearestPlayer = players[0];
            for (int i = 0; i < players.Count; i++)
            {
                if (Vector3.Magnitude(startPoint - nearestPlayer.transform.position) > Vector3.Magnitude(startPoint - players[i].transform.position))
                {
                    nearestPlayer = players[i];
                }
            }
            return nearestPlayer;
        }
        else
        {
            return null;
        }
    }
}
