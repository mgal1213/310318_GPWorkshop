using UnityEngine;
using BehaviourMachine;
using Akatsuki;

[NodeInfo(category = "Action/Animator/")]
public class PlayAnimationNode : ActionNode
{
    public Animator Animator;
    public StringVar State;
    public FsmEvent OnFinished;
    public bool WaitUntilFinish = true;
    private Status m_status;

    public override void Start()
    {
        base.Start();
        if (Animator == null)
            return;
        if (WaitUntilFinish)
        {
            CoroutineManager.I.StartCoroutine(Animator.Restart(State, Finish));

            m_status = Status.Running;
        }
        else
        {
            Animator.Play(State, 0, 0);
            Finish();
        }
    }

    public override Status Update()
    {
        return m_status;
    }

    private void Finish()
    {
        m_status = Status.Success;
        if (OnFinished.id != 0)
        {
            blackboard.SendEvent(OnFinished.id);
        }
    }
}
