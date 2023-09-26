using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public float XLock = -58;
    private float lockPos = 0;

    void Update()
    {
        transform.rotation = Quaternion.Euler(XLock,90,lockPos);
    }
}
