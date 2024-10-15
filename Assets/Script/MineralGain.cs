using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MineralGain : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI mineralGain;
    public float totalMineralGet;
    public static MineralGain Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void AddMineral(float mineralAmount)
    {
        totalMineralGet += mineralAmount;
        mineralGain.text = "Mineral amount : " + totalMineralGet.ToString();
    }
}
