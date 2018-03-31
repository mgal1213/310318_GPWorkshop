using UnityEngine;
using System.Collections;
using BehaviourMachine;

[RequireComponent(typeof(StateMachine))]
public class BulletAttackController : MonoBehaviour
{
    public float Speed;
    public Vector3 Size = new Vector3(0.2f, 0.2f, 0.2f);

    // Use this for initialization
    void Start()
    {
        Apply();
    }

    public void Apply()
    {
        GetComponent<StateMachine>().blackboard.GetFloatVar("Speed").Value = Speed;
        this.transform.localScale = Size;
    }
}
