using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float defaultAngle = 90f;

    private void Start()
    {
        RotateObjectToDirection(Vector3.zero);
    }

    private void RotateObjectToDirection(Vector3 direction)
    {
        var dir = direction - transform.position;
        dir.Normalize();

        var rotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotation - defaultAngle);
    }
}
