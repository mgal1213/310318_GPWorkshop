using UnityEngine;
using BehaviourMachine;
[NodeInfo(category = "Function/UnityChan/")]
public class OnControllerColliderHit : FunctionNode
{
    [VariableInfo(requiredField = false, nullLabel = "Don't Store", canBeConstant = false, tooltip = "Stores the amount of damage")]
    public GameObjectVar onHit; // Stores the amount of damage.

    // This function is called to reset the default values of the node
    public override void Reset()
    {
        base.Reset();   // Reset the enabled property
        this.onHit = new ConcreteGameObjectVar();
    }

    // Called when the BehaviourTree is enabled
    public override void OnEnable()
    {
        if (this.enabled)
        {
            var controller = this.blackboard.GetComponent<UnityChanController>();
            controller.OnControllerColliderHitEvent += OnControllerColliderHitEventCallBack;
            m_Registered = true;
        }
    }

    // Called when the BehaviourTree is disabled
    public override void OnDisable()
    {
        var controller = this.blackboard.GetComponent<UnityChanController>();
        controller.OnControllerColliderHitEvent -= OnControllerColliderHitEventCallBack;
        m_Registered = false;
    }

    void OnControllerColliderHitEventCallBack(GameObject onHit)
    {
        // Update the damage value
        this.onHit.Value = onHit;
        // Tick children
        this.OnTick();
    }
}