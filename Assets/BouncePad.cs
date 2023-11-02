using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public GameObject player;

    public float additionalForce;

    void OnCollisionEnter(Collision collision) 
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject == player) 
        {
            // Calculate the reflection vector 
            Vector3 incidentVector = player.transform.InverseTransformDirection(collision.relativeVelocity);
            Vector3 normalVector = collision.contacts[0].normal;
            Vector3 reflectionVector = Vector3.Reflect(incidentVector, normalVector);

            reflectionVector = Vector3.Normalize(reflectionVector) * additionalForce;
            Vector3 bounceVector = Vector3.Normalize(normalVector) * additionalForce;

            // Apply a force in the direction of the reflection vector 
            // player.GetComponent<Rigidbody>().AddForce(reflectionVector, ForceMode.Impulse);
            player.GetComponent<Rigidbody>().AddForce(transform.up * additionalForce, ForceMode.Impulse);
        }
    }
}
