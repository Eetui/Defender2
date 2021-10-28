using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetTrailOnDisable : MonoBehaviour
{
    private TrailRenderer tr;

    void Awake()
    {
        tr = GetComponent<TrailRenderer>();
    }

    private void OnDisable()
    {
        tr.Clear();
    }
}
