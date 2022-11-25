using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    private float direction
    {
        get
        {
            return -player.transform.rotation.eulerAngles.y;
        }
    }

    [SerializeField]
    GameObject trigger;

    [SerializeField]
    Player player;

    private void Start()
    {
        SetCompassRotation();
    }

    private void Update()
    {
        SetCompassRotation();
    }

    private void SetCompassRotation()
    {
        trigger.transform.localRotation = Quaternion.Euler(new Vector3(154.791f, -10.194f, direction - 3.817993f));
    }
}
