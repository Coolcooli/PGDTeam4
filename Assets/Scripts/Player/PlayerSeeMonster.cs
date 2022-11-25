using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSeeMonster : MonoBehaviour
{
    public UnityEvent OnSeeMonster;
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform monster;

    private bool hasInvoked = false;
    public bool ShouldStartChecking { set; private get; }

    private void Update()
    {
        if (hasInvoked || !ShouldStartChecking) return;

        Vector3 monsterDirection = monster.position - player.position;
        float angle = Mathf.Acos(Vector3.Dot(player.forward, monsterDirection.normalized));
        if (angle <= 1.2f && angle > 0.5f)
        {
            OnSeeMonster.Invoke();
            hasInvoked = true;
        }
    }
}
