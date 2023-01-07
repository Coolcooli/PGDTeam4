using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AddMaterialOnLook : MonoBehaviour
{
    // The material to be added to the GameObject
    public Material outlineMaterial;
    public Material transparentMaterial;


    // The angle of the field of view in degrees
    public float fieldOfViewAngle = 45f;

    // The maximum distance at which the material can be added
    public float maxDistance = 10f;

    // The player's transform
    public Transform playerTransform;

    // The renderer component of the GameObject
    private Renderer renderer;

    public bool hasMaterial = false;
    private int materialIndex = 0;
    private Material materialInstance;
    private Material originalMaterial;


    void Start()
    {
        // Get the renderer component of the GameObject
        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        // Calculate the angle between the player's forward direction and the direction to the GameObject
        float angle = Vector3.Angle(playerTransform.forward, transform.position - playerTransform.position);

        // Calculate the distance between the player and the GameObject
        float distance = Vector3.Distance(playerTransform.position, transform.position);
        // Check if the player is looking close to the GameObject and the distance is within the maximum distance
        if (angle < fieldOfViewAngle * 0.5f && distance < maxDistance)
        {
            if(!hasMaterial)
            {
                hasMaterial = true;
                materialInstance = AddMaterial();
            }
  
        } else
        {
            if (distance > maxDistance && hasMaterial)
            {
                Debug.Log("Delete");
                DeleteMaterial();
            }
        } 
    }

    // Remove the material from the GameObject
    public void DeleteMaterial()
    {
        hasMaterial = false;

        List<Material> materialsList = renderer.materials.ToList();

        // Remove the material instance from the list
        materialsList.Clear();
        materialsList.Add(originalMaterial);

        // Set the GameObject's materials to the updated list
        renderer.materials = materialsList.ToArray();

    }

    public Material AddMaterial()
    {
        List<Material> materialsList = renderer.materials.ToList();
        originalMaterial = materialsList[0];
        materialsList.Clear();
        Material addedMat = new Material(outlineMaterial);
        materialsList.Insert(0, addedMat);
        materialsList.Insert(1, transparentMaterial);
        renderer.materials = materialsList.ToArray();
        return addedMat;
    }
}