using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Thrust;
    public float Jump_Thrust;
    public float Max_Speed;

    private Rigidbody rb;
    private float Jump_CD = 1;
    

    
    private int Position;
    void Start()
    {
        Position = 1;//0-left 1-center 2-right
        rb = GetComponent<Rigidbody>();
    }
    bool isMoving = false;
    bool Move_Left = false;
    bool Move_Right = false;
    void Update()
    {
        if (!Game_Over)
            Check_Movement();
    }

    void Check_Movement()
    {
    if(Input.GetKey(KeyCode.A) && Position > 0 && isMoving== false)
        {
            isMoving = true;
            Move_Left = true;
            Position--;
        }
        if (Input.GetKey(KeyCode.D) && Position < 2 && isMoving == false)
        {
            isMoving = true;
            Move_Right = true;
            Position++;
        }
        if (Move_Left) transform.position -= Vector3.forward * 0.10f;
        if (Move_Right) transform.position += Vector3.forward * 0.10f;
        if ((transform.position.z <= 0.05f && transform.position.z >= -0.05f) || transform.position.z >= 2.5 || transform.position.z <= -2.5)
        {
            Move_Left = false;
            Move_Right = false;
            isMoving = false;
        }  
        
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) && Jump_CD <= 0 && rb.velocity.y == 0)
        {
            rb.AddForce(0, Jump_Thrust, 0);
            Jump_CD = 1;
        }
        Jump_CD -= Time.deltaTime;

        if (rb.velocity.y < 2 && rb.velocity.y > -2) rb.AddForce(0, - Jump_Thrust/17, 0);  
    }

    public static bool Game_Over = false;
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Obstacle")
        {
            Game_Over = true;
        }
    }
}
