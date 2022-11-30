using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenLocationRemapper : MonoBehaviour
{
    [SerializeField] private Transform targetObject;

    private const float minValue = -.71f;
    private const float maxValue = .71f;

    private const float maxX = 200;
    private const float maxZ = 200;

    private void FixedUpdate()
    {
        RemapMonsterLocation();
    }

    /// <summary>
    /// This function remaps the location of the monster to the correct position on the screen.
    /// </summary>
    private void RemapMonsterLocation()
    {
        float targetX = MathAdditions.Remap(targetObject.position.x, -maxX, maxX, minValue, maxValue);
        float targetY = MathAdditions.Remap(targetObject.position.z, -maxZ, maxZ, minValue, maxValue);

        transform.localPosition = new Vector3(targetX, targetY, transform.localPosition.z);
    }
}
