using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour, IDamageable
{
    public GameObject[] PlayerLife;
    private int actualLifeLoss;

    public bool isDamageable { get { return true; } }

    public void onDmg()
    {
        if (actualLifeLoss < PlayerLife.Length) 
        {
            PlayerLife[actualLifeLoss].SetActive(false);
            actualLifeLoss++;
        }
    }
}
