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
    [SerializeField]
    private Transform afterKillLocation;

    private bool isAttacking = false;

    public UnityEvent hasKilledTarget;
    public UnityEvent startDialoge;
    private List<SkinnedMeshRenderer> skinnedMeshes = new List<SkinnedMeshRenderer>();

    private void Start()
    {
        skinnedMeshes.AddRange(GetComponentsInChildren<SkinnedMeshRenderer>());
        transform.position = startLocation.position;
    }

    private void FixedUpdate()
    {
        if (!isAttacking) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, 1f);
        transform.LookAt(target);
        CheckTargetDistance();
    }

    public void AttackCaptain()
    {
        foreach (SkinnedMeshRenderer mesh in skinnedMeshes)
            mesh.enabled = true;
        isAttacking = true;
    }

    private void CheckTargetDistance()
    {
        if (Vector3.Distance(transform.position, target.position) < 1)
        {
            hasKilledTarget.Invoke();
            StartCoroutine(dialogeDelay());
            target = afterKillLocation;
        }
    }

    IEnumerator dialogeDelay()
    {
        yield return new WaitForSeconds(1.3f);
        startDialoge.Invoke();
    }
}
