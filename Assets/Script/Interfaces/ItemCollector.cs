using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        ICollectable collectable = other.GetComponent<ICollectable>();
        if (collectable==null )return;
        if (!collectable.isCollectable) return;

        collectable.OnCollected();
    }
}
