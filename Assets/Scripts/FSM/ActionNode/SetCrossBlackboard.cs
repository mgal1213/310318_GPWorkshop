using BehaviourMachine;

public class SetIntCrossBlackboard : ActionNode
{
    public StateMachine Target;
    public string Key;
    public int Value;

    public override void OnEnable()
    {
        Target.blackboard.GetIntVar(Key).Value = Value;
    }

    public override Status Update()
    {
        return Status.Success;
    }
}