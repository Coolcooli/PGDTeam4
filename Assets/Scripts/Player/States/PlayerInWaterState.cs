using UnityEngine;

public class PlayerInWaterState : PlayerBaseState
{
    public PlayerInWaterState(Player context, PlayerStateFactory factory, PlayerMovement movement) : base(context, factory, movement)
    {
        IsRootState = true;
        InitializeSubState();
    }

    public override void UpdateState()
    {
        if (Movement.IsJumpPressed)
        {
            Movement.Velocity = Vector3.up * Movement.WaterSpeed;
        }
        else if (Movement.IsCrouchPressed)
        {
            Movement.Velocity = Vector3.up * -Movement.WaterSpeed;
        }
        else
        {
            Movement.Velocity = Vector3.zero;
        }
    }

    public override void ExitState()
    {
        Movement.Velocity = Vector3.zero;
    }

    public override void CheckSwitchStates()
    {
        if (Context.CurrentWaterColliders > 0 && Context.CurrentAirColliders > 0)
            SwitchState(Factory.Floating());

        if (!Context.IsInWater)
        {
            if (Movement.IsGrounded)
                SwitchState(Factory.Grounded());
            else
                SwitchState(Factory.Jump());
        }
    }

    public override void InitializeSubState()
    {
        if (Movement.IsMoving)
            SetSubState(Factory.Walk());
        else
            SetSubState(Factory.Idle());
    }
}
