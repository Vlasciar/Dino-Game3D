﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Fwd : MonoBehaviour
{

    public float DriveSpeed = 1;


    private void Start()
    {

    }
    void FixedUpdate()
    {
        //nextPosition = transform.position + DriveSpeed * Vector3.right;
        if (!Player.Game_Over)
            transform.position += DriveSpeed * Vector3.right;

    }
}
