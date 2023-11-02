using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPad : MonoBehaviour
{
    public GameObject correspondingPad;

    private void Update()
    {
        transform.position = correspondingPad.transform.position;
        transform.rotation = correspondingPad.transform.rotation;
    }
}
