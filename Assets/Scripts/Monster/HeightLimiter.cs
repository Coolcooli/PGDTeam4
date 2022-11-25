using System.Collections;
using System.Collections.Generic;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.Events;

public class HeightLimiter : MonoBehaviour
{
    public UnityEvent<Transform> OnPlayerAboveLimit;
    [SerializeField]
    private float maxHeight = 50f;
    [SerializeField]
    Transform player;
    private bool hasTriggered = false;

    private void Update()
    {
        if (hasTriggered) return;

        if (player.position.y > maxHeight)
        {
            hasTriggered = true;
            OnPlayerAboveLimit.Invoke(player);
        }
    }
}
