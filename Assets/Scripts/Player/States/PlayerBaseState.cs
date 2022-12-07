using UnityEngine;

public abstract class PlayerBaseState
{
    private bool isRootState = false;
    private Player context;
    private PlayerMovement movement;
    private PlayerStateFactory factory;
    private PlayerBaseState currentSuperState;
    private PlayerBaseState currentSubState;

    protected bool IsRootState { set { isRootState = value; } }
    protected Player Context { get { return context; } }
    protected PlayerMovement Movement { get { return movement; } }
    public PlayerStateFactory Factory { get { return factory; } }

    public PlayerBaseState(Player context, PlayerStateFactory factory, PlayerMovement movement)
    {
        this.context = context;
        this.factory = factory;
        this.movement = movement;
    }

    // Declare virtual functions so that all of the inherited classes can overwrite them and have an own implementation
    public virtual void EnterState() { }

    public virtual void UpdateState() { }

    public virtual void CheckSwitchStates() { }

    public virtual void ExitState() { }

    public virtual void InitializeSubState() { }

    // Handles all updates. Only this function is called in the update in the context
    public void UpdateStates()
    {
        UpdateState();
        CheckSwitchStates();
        if (currentSubState != null)
        {
            currentSubState.UpdateStates();
        }
    }

    // Used to switch between all of the states
    // Executes the EnterState of the 'old' state, then runs the ExitState of the new state
    // Furthermore it checks if the state is a root (top of the state hierarchy)
    // Finally it checks if there is a super state, if there isn't one it will set the substate to the new state
    public void SwitchState(PlayerBaseState newState)
    {
        ExitState();

        newState.EnterState();

        if (isRootState)
        {
            context.CurrentState = newState;
        }
        else if (currentSuperState != null)
        {
            currentSuperState.SetSubState(newState);
        }
    }

    protected void SetSuperState(PlayerBaseState newSuperState)
    {
        currentSuperState = newSuperState;
    }

    protected void SetSubState(PlayerBaseState newSubState)
    {
        currentSubState = newSubState;
        newSubState.SetSuperState(this);
    }
}
