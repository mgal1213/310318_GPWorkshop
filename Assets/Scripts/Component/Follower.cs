using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform FollowOn;

    public float DistanceY;
    public float DistanceZ;

    [Range(0, 1)]
    public float LerpParam;

    [Range(0, 1)]
    public float SlowTimeScale = 0.5f;

    private Tween m_tween;

    void Update()
    {
        transform.LookAt(FollowOn);

        var distance = Vector3.Distance(this.transform.position, FollowOn.position);
        var targetPos = FollowOn.transform.position;
        var targetY = DistanceY;
        var targetZ = DistanceZ;
        if (distance < 20)
        {
            targetY = -targetY;
            targetZ = -targetZ;
        }

        targetPos.y += targetY;
        targetPos.z += targetZ;

        var lerpPosition = Vector3.Lerp(transform.position, targetPos, LerpParam);
        transform.position = lerpPosition;

        CalculateTimeScale();
    }

    private void CalculateTimeScale()
    {
        if (m_tween != null)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = SlowTimeScale;
            m_tween = DOVirtual.DelayedCall(2, () =>
            {
                Time.timeScale = 1;
                m_tween = null;
            });
        }
    }
}