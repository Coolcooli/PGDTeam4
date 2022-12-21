using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : Interactable
{
    new private Rigidbody rigidbody;
    new private Collider collider;

    [SerializeField]
    private Vector3 holdRotation;
    [SerializeField]
    private Vector3 holdOffset = new Vector3(0.5f, 0.4f, 0.6f);
    [SerializeField]
    private float holdScale = 1;
    private Vector3 scale;

    void Awake()
    {
        //stores the real scale
        scale = transform.localScale;

        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();
    }

    /// <summary>
    /// attaches the object to the player that picks it up
    /// </summary>
    /// <param name="player">the player that picks it up</param>
    public virtual void Pickup(GameObject player)
    {
        //sets the location to the hand and the parent to the player
        transform.parent = player.transform;
        transform.localPosition = holdOffset;
        transform.localScale = new Vector3(holdScale, holdScale, holdScale);
        transform.localEulerAngles = holdRotation;

        //disables gravity and collision
        rigidbody.isKinematic = true;
        collider.enabled = false;
    }
    /// <summary>
    /// transfers the object from the player back to the environment
    /// </summary>
    /// <param name="player">player that drops the item</param>
    public void Drop()
    {
        transform.parent = null;
        transform.localScale = scale;

        //enables gravity and collision
        rigidbody.isKinematic = false;
        collider.enabled = true;

        rigidbody.AddForce(((transform.forward*.5f) + transform.up) * 150);
    }

    public void DoDestroy()
    {
        Destroy(this.gameObject);
    }
}
