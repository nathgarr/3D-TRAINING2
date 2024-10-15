using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelController : MonoBehaviour, ICollectable
{
    [SerializeField] float mineralGainValue = 1;
    public bool isCollectable { get { return true; } }

    public  void OnCollected()
    {
        MineralGain.Instance.AddMineral(mineralGainValue);
        Destroy(gameObject);
    }
}
