using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public GameObject player;
    public Rigidbody playerRigidbody;

    public float smoothSpeed = 9f;

    public float upperSpeedLimit;
    public float lowerSpeedLimit;

    public float minCameraDistance;
    public float maxCameraDistance;

    public Vector3 offset;

    private float _currentOffsetlimit;
    


    void Update()
    {
        
    }

    void FixedUpdate () 
    {
        Vector3 requiredCamPosition;
        float speed = playerRigidbody.velocity.magnitude;
        if (speed < upperSpeedLimit && speed > upperSpeedLimit)
        {
            if (_currentOffsetlimit < minCameraDistance)
            {
                _currentOffsetlimit = minCameraDistance;
            }
            else if (_currentOffsetlimit > maxCameraDistance)
            {
                _currentOffsetlimit = maxCameraDistance;
            }
            else
            {
                _currentOffsetlimit = speed - lowerSpeedLimit;
            }

        }
        Vector3 speedOffset = new Vector3(0, 0, _currentOffsetlimit);
        Vector3 playerPostion = target.position + offset + speedOffset;
        Vector3 smoothenedPosition = Vector3.Lerp(transform.position, playerPostion, smoothSpeed * Time.deltaTime);
        transform.position = smoothenedPosition;
    }
}
