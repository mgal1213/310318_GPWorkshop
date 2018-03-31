using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnDamageDelegate(float f);

public class SoldierController : MonoBehaviour
{
    public event OnDamageDelegate OnDamageEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ChanAttack")
        {
            if (OnDamageEvent != null)
                OnDamageEvent(1);
        }
    }
}
