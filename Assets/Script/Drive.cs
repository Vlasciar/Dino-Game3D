using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{

    public float DriveSpeed = 1;
    bool direction;
    private Vector3 nextPosition;
    public float offset_speed = 0;


    private void Start()
    {

    }
    void Update()
    {
        nextPosition = transform.position + DriveSpeed * Vector3.right;
        transform.position = nextPosition;

    }
}
