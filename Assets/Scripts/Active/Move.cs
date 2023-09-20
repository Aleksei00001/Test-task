using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public void MoveDirection(Vector3 direction, float spead, GameObject moveGameObject)
    {
        moveGameObject.transform.position += direction * spead * Time.deltaTime;
    }

    public float MoveTarget(GameObject target, float spead, GameObject moveGameObject)
    {
        moveGameObject.transform.position += (target.transform.position - moveGameObject.transform.position).normalized * spead * Time.deltaTime;
        return ((target.transform.position - moveGameObject.transform.position).normalized * spead * Time.deltaTime).x;
    }
}
