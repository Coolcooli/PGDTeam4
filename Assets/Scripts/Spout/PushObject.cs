using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObject : MonoBehaviour
{
    private List<Rigidbody> affectedObjects = new List<Rigidbody>();
    private CharacterController player;
    private const float objStrength = 800f;
    private const float playerStrength = 8f;
    private const float maxVelocity = 3f;

    [SerializeField]
    private bool isActive = false;
    [SerializeField]
    private bool isEnabled = true;

    [SerializeField]
    private float duration = 5f;

    [SerializeField]
    new private ParticleSystem particleSystem;

    private void Awake()
    {
        if (isActive && !isEnabled)
            isActive = false;
    }

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
        if (!isEnabled) return;

        Invoke("SetActive", .5f);
        particleSystem.Play();
        if (endWithDuration)
            Invoke("Deactivate", duration);
    }

    private void SetActive()
    {
        isActive = true;
    }

    public void Enable()
    {
        isEnabled = true;
    }
}
