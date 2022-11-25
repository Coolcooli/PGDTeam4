using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    private List<Rigidbody> affectedObjects = new List<Rigidbody>();
    private CharacterController player;
    private const float objStrength = 1350f;
    private const float playerStrength = 8f;
    private const float maxVelocity = 20f;

    [SerializeField]
    private bool isActive = false;
    public bool IsActive { set { isActive = value; } }

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
                obj.AddForce(transform.forward * PushStrength(obj.position) * objStrength * Time.deltaTime);
        }
        if (player)
            player.Move(transform.forward * PushStrength(player.transform.position) * playerStrength * Time.deltaTime);
    }

    private float PushStrength(Vector3 objPos)
    {
        float distance = Vector3.Distance(objPos,transform.position);
        float strength = 1 / distance;
        return strength;
    }
}
