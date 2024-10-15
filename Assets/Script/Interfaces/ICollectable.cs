using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    bool isCollectable { get; }
    void OnCollected();
}
