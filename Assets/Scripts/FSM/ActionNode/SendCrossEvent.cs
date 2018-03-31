using BehaviourMachine;

public class SendCrossEvent : ActionNode
{
    public StateMachine Target;
    public string Event;

    public override void OnEnable()
    {
        Target.SendEvent(Event);
    }

    public override Status Update()
    {
        return Status.Success;
    }
}
