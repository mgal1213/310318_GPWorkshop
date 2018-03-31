using UnityEngine;
using System.Collections;

public delegate void OnControllerColliderHitDelegate(GameObject hit);
public class UnityChanController : MonoBehaviour
{
    public event OnDamageDelegate OnDamageEvent;
    public event OnControllerColliderHitDelegate OnControllerColliderHitEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyAttack")
        {
            if (OnDamageEvent != null)
                OnDamageEvent(1);
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3F)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * 2.0f;
        if (OnDamageEvent != null)
            OnControllerColliderHitEvent(hit.gameObject);
    }
}