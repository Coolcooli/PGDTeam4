using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLocation : MonoBehaviour
{
    [SerializeField] private Transform monster;

    private const float minValue = -.71f;
    private const float maxValue = .71f;

    [SerializeField] private float maxMonsterX = 200;
    [SerializeField] private float maxMonsterZ = 200;

    private void FixedUpdate()
    {
        RemapMonsterLocation();
    }

    /// <summary>
    /// This function remaps the location of the monster to the correct position on the screen.
    /// </summary>
    private void RemapMonsterLocation()
    {
        float targetX = MathAdditions.Remap(monster.position.x, -maxMonsterX, maxMonsterX, minValue, maxValue);
        float targetY = MathAdditions.Remap(monster.position.z, -maxMonsterZ, maxMonsterZ, minValue, maxValue);

        transform.localPosition = new Vector3(targetX, targetY, transform.localPosition.z);
    }
}
