using UnityEngine;
using BehaviourMachine;

[NodeInfo(category = "Action/Animator/")]
public class AnimatorSpeedNode : ActionNode
{
    public Animator Animator;
    public FloatVar Speed;

    public override void Start()
    {
        base.Start();

        Animator.speed = Speed.Value;
    }

    public override Status Update()
    {
        return Status.Success;
    }
}
