using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AttackPlayer : MonoBehaviour
{
    public UnityEvent OnPlayerDeath;
    private float spawnDistance = 200f;
    private bool isAttacking = false;
    private Transform player;
    private float movementSpeed = 50f;
    private List<SkinnedMeshRenderer> skinnedMeshes = new List<SkinnedMeshRenderer>();

    private void Awake()
    {
        skinnedMeshes.AddRange(GetComponentsInChildren<SkinnedMeshRenderer>());
    }

    public void Attack(Transform player)
    {
        this.player = player;
        Vector3 targetPosition = -player.forward * spawnDistance + new Vector3(0, player.position.y, 0);
        transform.position = targetPosition;
        foreach (SkinnedMeshRenderer mesh in skinnedMeshes)
            mesh.enabled = true;

        isAttacking = true;
    }

    private void Update()
    {
        if (!isAttacking) return;

        Vector3 targetDirection = player.position - transform.position;
        targetDirection.Normalize();
        transform.position += targetDirection * movementSpeed * Time.deltaTime;
        transform.LookAt(player.position);

        if (Vector3.Distance(transform.position, player.position) < 1)
            OnPlayerDeath.Invoke();
    }
}
