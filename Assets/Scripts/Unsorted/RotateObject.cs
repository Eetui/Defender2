using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float defaultAngle = 90f;

    public void RotateObjectToDirection()
    {
        var dir = Vector3.zero - transform.position;
        dir.Normalize();

        var rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation - defaultAngle);
    }
}
