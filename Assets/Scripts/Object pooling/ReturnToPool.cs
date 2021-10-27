using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    private ObjectPooler _objectPooler;

    private void Start() => _objectPooler = ObjectPooler.Instance;


    private void OnDisable()
    {
        if (_objectPooler != null)
            _objectPooler.ReturnObjectToPool(gameObject);
    }
}
