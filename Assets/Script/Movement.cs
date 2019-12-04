using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Thrust;
    public float Jump_Thrust;
    public float Max_Speed;
    private float Jump_CD = 1;
    public Rigidbody rb;
    bool InJump = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate()
    {
        if (rb.velocity.y == 0)
        {
            InJump = false;
        }
        if (rb.velocity.z <= Max_Speed)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (InJump == false)
                    rb.AddForce(0, 0, 1 * Thrust);
                else rb.AddForce(0, 0, 1 * Thrust / 3);
            }
        }

        if (rb.velocity.z >= -Max_Speed)
        {
            if (Input.GetKey(KeyCode.A))
            {
                if(InJump==false)
                rb.AddForce(0, 0, -1 * Thrust);
                else rb.AddForce(0, 0, -1 * Thrust/3);
            }
        }

        if (Input.GetKey(KeyCode.Space) && Jump_CD <= 0 && rb.velocity.y == 0)
        {
            InJump = true;
            rb.AddForce(0, Jump_Thrust, 0);
            Jump_CD = 1;
        }
        Jump_CD -= Time.deltaTime;
    }
}
