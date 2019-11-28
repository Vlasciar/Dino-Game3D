using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{

    public float DriveSpeed = 1;

    private void Start()
    {

    }
    void Update()
    {
        transform.position += DriveSpeed * Vector3.right;

    }
}
