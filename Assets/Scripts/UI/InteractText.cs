using TMPro;
using UnityEngine;

public class InteractText : MonoBehaviour
{
    TextMeshProUGUI textComponent;
    int range = PlayerInteract.InteractRange;
    // Start is called before the first frame update
    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = "";
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range) && hit.transform.tag == "Interactable"){
            if (hit.transform.GetComponent<Pickupable>() != null)
            {
                textComponent.text = "press E to pickUp";
            }else{
                textComponent.text = "press E to interact";
            }
        }
    }
}
