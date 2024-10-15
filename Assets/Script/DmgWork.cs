using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DmgWork : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable == null) return;
        if (!damageable.isDamageable) return;

        damageable.onDmg();
    }
}
