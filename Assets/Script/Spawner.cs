using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int counter;
    public GameObject[] Jewel;

    private void Start()
    {
        SpawnJewel();
    }

    public void SpawnJewel()
    {
        if (counter > 0)
        {
            Instantiate(Jewel[Random.Range(0, Jewel.Length)], transform.position, Quaternion.identity);
        }
    }
}
