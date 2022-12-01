using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Transform startLocation;

    private WaypointSystem waypointSystem;

    private bool isAttacking = false;

    public UnityEvent hasKilledTarget;
    private List<SkinnedMeshRenderer> skinnedMeshes = new List<SkinnedMeshRenderer>();

    private void Awake()
    {
        waypointSystem = GetComponent<WaypointSystem>();
        skinnedMeshes.AddRange(GetComponentsInChildren<SkinnedMeshRenderer>());
        transform.position = startLocation.position;
    }

    private void Update()
    {
        CheckTargetDistance();
    }

    public void AttackTarget(Transform target)
    {
        waypointSystem.SetWaypoint(target);
        waypointSystem.MovementSpeed = 70f;

        isAttacking = true;
    }

    public void AttackCaptain()
    {
        print("attack");
        foreach (SkinnedMeshRenderer mesh in skinnedMeshes)
            mesh.enabled = true;
        AttackTarget(target);
        transform.LookAt(target);
        hasKilledTarget.AddListener(DisableObject);
    }

    private void CheckTargetDistance()
    {
        if (!isAttacking) return;

        if (Vector3.Distance(transform.position, waypointSystem.CurrentTarget.transform.position) < 1)
        {
            Destroy(target);
            hasKilledTarget.Invoke();
        }
    }

    private void DisableObject()
    {
        Destroy(gameObject);
    }
}
