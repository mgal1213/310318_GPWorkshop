using UnityEngine;
using System.Collections;
using BehaviourMachine;
using System.Collections.Generic;
using System.Linq;
using Akatsuki;

namespace Compass.Enemy.AI
{
    [NodeInfo(category = "Composite/")]
    public class YieldSequence : CompositeNode
    {
        private List<ActionNode> m_childs;
        private ActionNode m_current;
        private Status m_status;
        private UnityEngine.Coroutine m_coroutine;

        public override void Start()
        {
            m_childs = new List<ActionNode>();
            m_childs.AddRange(children.ToList());
            m_current = m_childs.FirstOrDefault();

            m_status = Status.Running;
            CoroutineManager.I.StopCoroutine(YieldUpdate());
            m_coroutine = CoroutineManager.I.StartCoroutine(YieldUpdate());
        }

        public override void End()
        {
            if (m_coroutine != null && CoroutineManager.I != null)
                CoroutineManager.I.StopCoroutine(m_coroutine);
            m_status = Status.Success;
        }

        private IEnumerator YieldUpdate()
        {
            while (m_current != null && m_current.status != Status.Failure && m_current.status != Status.Error)
            {
                m_current.OnTick();

                switch (m_current.status)
                {
                    case Status.Ready:
                        break;
                    case Status.Success:
                        m_current = Next();
                        break;
                    case Status.Failure:
                        m_status = Status.Failure;
                        break;
                    case Status.Error:
                        m_status = Status.Error;
                        break;
                    case Status.Running:
                        m_status = Status.Running;
                        break;
                }

                yield return new WaitForEndOfFrame();
            }
            m_status = Status.Success;
        }

        public override Status Update()
        {
            return m_status;
        }

        private ActionNode Next()
        {
            m_childs.Remove(m_current);
            m_current = m_childs.FirstOrDefault();
            return m_current;
        }
    }
}