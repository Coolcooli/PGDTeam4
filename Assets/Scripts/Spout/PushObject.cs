using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    private List<Rigidbody> affectedObjects = new List<Rigidbody>();
    private CharacterController player;
    private const float objStrength = 800f;
    private const float playerStrength = 8f;
    private const float maxVelocity = 20f;

    [SerializeField]
    private bool isActive = false;

    [SerializeField]
    private float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
            affectedObjects.Add(other.attachedRigidbody);
        else if (other.GetComponent<CharacterController>())
            player = other.GetComponent<CharacterController>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.velocity = Vector3.zero;
            affectedObjects.Remove(other.attachedRigidbody);
        }
        else if (other.GetComponent<CharacterController>())
        {
            player = null;
        }
    }

    private void FixedUpdate()
    {
        if (!isActive) return;

        foreach (Rigidbody obj in affectedObjects)
        {
            if (obj.velocity.magnitude < maxVelocity)
                obj.AddForce(transform.forward * objStrength * Time.deltaTime);
        }
        if (player)
            player.Move(transform.forward * playerStrength * Time.deltaTime);
    }
    public void Deactivate()
    {
        isActive = false;
    }

    public void Activate(bool endWithDuration = false)
    {
        isActive = true;
        if (endWithDuration)
            Invoke("Deactivate", duration);
    }
}
