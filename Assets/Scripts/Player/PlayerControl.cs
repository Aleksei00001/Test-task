using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Projectile projectile;

    [SerializeField] private Player player;
    [SerializeField] private VirtualJoystick virtualJoystick;
    [SerializeField] private Move move;
    [SerializeField] private Shot shot;

    private bool isShot;

    private float shotCooldawn;

    private int segmentsDrawCircle = 100;

    private void Update()
    {
        move.MoveDirection(virtualJoystick.Value, player.spead, this.gameObject);
        shotCooldawn -= Time.deltaTime;
        if (isShot == true)
        {
            ShotOnNearestEnemyTarget();
        }
        if (player.inventory.weapon != null)
        {
            DrawCircle();
        }
    }

    public void ShotOnNearestEnemyTarget()
    {
        if (player.inventory.weapon != null)
        {
            if (shotCooldawn <= 0)
            {
                if (player.inventory.FindItem(player.inventory.weapon.itemUse) != null)
                {
                    Enemy newTargetEnymy = player.objectList.FindNearestEnemy(this.gameObject.transform.position);
                    if (newTargetEnymy != null)
                    {
                        if (Vector3.Magnitude(newTargetEnymy.transform.position - this.transform.position) < player.inventory.weapon.attackDistance)
                        {
                            shot.ShotOnTarget(newTargetEnymy.gameObject, player.inventory.weapon);
                            player.inventory.ReduceItemCount(player.inventory.weapon.itemUse, 1);
                            shotCooldawn = player.inventory.weapon.shotRecharge;
                        }
                    }
                }
            }
        }
    }


    public void SetIsShot(bool newIsShot)
    {
        isShot = newIsShot;
    }


    [SerializeField] private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer.positionCount = segmentsDrawCircle + 1;
        lineRenderer.useWorldSpace = false;


    }

    void DrawCircle()
    {
        float deltaTheta = (2f * Mathf.PI) / segmentsDrawCircle;
        float theta = 0f;

        for (int i = 0; i < segmentsDrawCircle + 1; i++)
        {
            float x = player.inventory.weapon.attackDistance * Mathf.Cos(theta);
            float y = player.inventory.weapon.attackDistance * Mathf.Sin(theta);

            Vector3 pos = new Vector3(x, y, 0);
            lineRenderer.SetPosition(i, pos);

            theta += deltaTheta;
        }
    }
}
