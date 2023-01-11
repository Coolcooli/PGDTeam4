using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintState : PlayerBaseState
{
    private float sprintMultiplier = 1.5f;
    public PlayerSprintState(Player context, PlayerStateFactory factory, PlayerMovement movement) : base(context, factory, movement) { }

    public override void EnterState()
    {
        Movement.SprintMultiplier = sprintMultiplier;
    }

    public override void CheckSwitchStates()
    {
        if (!Movement.IsMoving)
            SwitchState(Factory.Idle());
        if (!Movement.IsSprinting)
            SwitchState(Factory.Walk());
    }

    public override void ExitState()
    {
        Movement.SprintMultiplier = 1f;
    }
}
