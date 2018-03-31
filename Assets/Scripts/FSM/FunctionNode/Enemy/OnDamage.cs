using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;
using UnityEngine;

[NodeInfo(category = "Function/Enemy/")]
public class OnDamage : FunctionNode
{
    [VariableInfo(requiredField = false, nullLabel = "Don't Store", canBeConstant = false, tooltip = "Stores the amount of damage")]
    public FloatVar damage; // Stores the amount of damage.

    // This function is called to reset the default values of the node
    public override void Reset()
    {
        base.Reset();   // Reset the enabled property
        this.damage = new ConcreteFloatVar();
    }

    // Called when the BehaviourTree is enabled
    public override void OnEnable()
    {
        if (this.enabled)
        {
            var controller = this.blackboard.GetComponent<SoldierController>();
            controller.OnDamageEvent += OnDamageCallback;
            m_Registered = true;
        }
    }

    // Called when the BehaviourTree is disabled
    public override void OnDisable()
    {
        var controller = this.blackboard.GetComponent<SoldierController>();
        controller.OnDamageEvent -= OnDamageCallback;
        m_Registered = false;
    }

    void OnDamageCallback(float damageParameter)
    {
        // Update the damage value
        this.damage.Value = damageParameter;
        // Tick children
        this.OnTick();
    }


}