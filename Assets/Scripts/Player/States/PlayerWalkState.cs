using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public PlayerWalkState(Player context, PlayerStateFactory factory, PlayerMovement movement) : base(context, factory, movement) { }

    public override void CheckSwitchStates()
    {
        if (!Movement.IsMoving)
            SwitchState(Factory.Idle());
        if (Movement.IsSprinting)
            SwitchState(Factory.Sprint());
    }
}
