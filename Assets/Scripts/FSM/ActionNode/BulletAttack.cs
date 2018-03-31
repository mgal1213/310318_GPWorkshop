using UnityEngine;
using BehaviourMachine;

[NodeInfo(category = "Action/Enemy/")]
public class BulletAttack : ActionNode
{
    public BulletAttackController BulletController;

    public float Speed;
    public Vector3 Size;

    public override void Start()
    {
        base.Start();

        var bullet = GameObject.Instantiate<BulletAttackController>(BulletController);
        bullet.Speed = Speed;
        bullet.Size = Size;
        bullet.Apply();

    }

    public override Status Update()
    {
        return Status.Success;
    }
}
