using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour
{
    [SerializeField]
    float maxPlayerHeight = 100f;
    [SerializeField]
    private Transform target;
    public Transform Target { set { target = value; } }

    private WaypointSystem waypointSystem;

    private bool isAttacking = false;
    private bool targetIsPlayer = false;

    private void Start()
    {
        waypointSystem = GetComponent<WaypointSystem>();
    }

    private void Update()
    {
        CheckTargetDistance();
        CheckTargetHeight();
    }

    private void CheckTargetHeight()
    {
        if (target.transform.position.y >= maxPlayerHeight)
        {
            AttackTarget(target.transform);
        }
    }

    private void AttackTarget(Transform target)
    {
        waypointSystem.SetWaypoint(target);
        waypointSystem.MovementSpeed = 70f;

        isAttacking = true;
    }

    private void CheckTargetDistance()
    {
        if (!isAttacking) return;

        if (Vector3.Distance(transform.position, waypointSystem.CurrentTarget.transform.position) < 1)
        {
            if (targetIsPlayer)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                Destroy(target);
            }
        }
    }
}
