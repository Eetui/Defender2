using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject Target;
    public bool disableOnTargetMissing = true;

    private void Update()
    {
        if(Target)
        {
            transform.position = Target.transform.position;
        }
        else if(disableOnTargetMissing)
        {
            gameObject.SetActive(false);
        }
    }
}
