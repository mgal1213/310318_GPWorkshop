using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviourMachine;

[NodeInfo(category = "Action/Renderer/", icon = "MeshRenderer", description = "Changes the color of the \"Game Object\"")]
public class FadeNode : ActionNode
{
    /// <summary>
    /// The game object to change the color.
    /// </summary>
    [VariableInfo(requiredField = false, nullLabel = "Use Self", tooltip = "The game object to change the color")]
    public GameObjectVar gameObject;

    public float Value;

    [System.NonSerialized]
    Renderer m_Renderer = null;

    private Color m_newColor;

    public override void Reset()
    {
        gameObject = new ConcreteGameObjectVar(this.self);

    }

    public override Status Update()
    {
        // Get the renderer
        if (m_Renderer == null || m_Renderer.gameObject != gameObject.Value)
            m_Renderer = gameObject.Value != null ? gameObject.Value.GetComponent<Renderer>() : null;
        m_newColor = m_Renderer.material.color;
        // Validate members
        if (m_Renderer == null)
            return Status.Error;
        m_newColor.a -= Value;
        m_Renderer.material.color = m_newColor;

        return Status.Success;
    }

}