using System.Collections;
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
        if (!Player.Game_Over && Player.Game_Start && ((Scorer.Score / 100f) / 100f) < 1 )
            transform.position += (DriveSpeed + (Scorer.Score / 100f) / 100f) * Vector3.right;

    }
}
