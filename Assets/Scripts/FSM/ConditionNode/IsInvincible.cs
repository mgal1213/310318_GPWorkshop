using UnityEngine;
using BehaviourMachine;

[NodeInfo(category = "Condition/UnityChan/")]
public class IsInvincible : ConditionNode
{
    public override Status Update()
    {
        var isInvincible = this.blackboard.GetBoolVar("IsInvincible").Value;
        if (isInvincible)
            return Status.Success;
        else
            return Status.Failure;
    }
}
