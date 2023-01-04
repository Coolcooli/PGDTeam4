using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{

    [SerializeField] private GameObject item;//the item that the octopus can drop
    [SerializeField] private Transform holdPos;
    private GameObject holdingItem;

    // Start is called before the first frame update

    /// <summary>
    /// makes a copy of the item for the octopus to hold
    /// </summary>
    private void Start(){
        holdingItem = Instantiate(item, new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z - 0.25f), transform.rotation, transform);
        holdingItem.transform.Rotate(new Vector3(0, 90, 0));
    }

    /// <summary>
    /// makes the octopus stop moving
    /// </summary>
    public void DropItem(){
        holdingItem.transform.parent = null;
        holdingItem.GetComponent<Rigidbody>().useGravity = true;
    }
}
