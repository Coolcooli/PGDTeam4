#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.ParticleSystem;

[ExecuteInEditMode]
public class SpoutSpecs : MonoBehaviour
{
    private BoxCollider boxCollider;

    [SerializeField]
    private float pushRange = 1;
    private float PushRange
    {
        get { return boxCollider.size.z; }
        set { pushRange = SetPushRange(value); SetParticleLifetime(value); }
    }

    [SerializeField]
    private float pushWidth = 1;
    private float PushWidth
    {
        get { return boxCollider.size.x; }
        set { pushWidth = SetPushWidth(value); }
    }

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        PushRange = pushRange;
        PushWidth = pushWidth;
    }

    private float SetPushRange(float value)
    {
        boxCollider.size = new Vector3(boxCollider.size.x, boxCollider.size.y, value);
        boxCollider.center = new Vector3(boxCollider.center.x, boxCollider.center.y, value / 2);
        return value;
    }

    private void SetParticleLifetime(float value)
    {
        ParticleSystem particle = GetComponentInChildren<ParticleSystem>();
        if (!particle) return;

        MainModule main = particle.main;
        main.startLifetime = value / main.startSpeed.constant;
    }

    private float SetPushWidth(float value)
    {
        boxCollider.size = new Vector3(value, boxCollider.size.y, boxCollider.size.z);
        return value;
    }
}
#endif