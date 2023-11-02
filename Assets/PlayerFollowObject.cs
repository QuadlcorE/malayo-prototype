using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowObject : MonoBehaviour
{
    public Transform player; 

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = player.position;
    }
}
