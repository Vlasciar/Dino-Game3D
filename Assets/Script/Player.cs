﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Thrust;
    public float Jump_Thrust;
    public float Max_Speed;


    public Animation Dino_Anim;
    public Animation Anim;
    public Animation Model_Anim;
    public Animation Cam_Abs;//ABSolute position
    public Animation Cam_Rel;//RELative position

    AudioSource audio;
    public AudioClip Sound_Jump;
    public AudioClip Sound_100pts;
    public AudioClip Sound_Game_Over;

    private int Position;

    public GameObject Txt_Score;
    public GameObject Txt_Dino_Runner;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        Txt_Score.SetActive(false);
        Position = 1;//0-left 1-center 2-right
    }
    bool First_Input = false;
    void Update()
    {
        if (Scorer.Score % 100 == 0 && Scorer.Score > 1 && !Game_Over && Game_Start )
            Sound_100pts_Play();

        if (!Game_Start)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                Anim.Play("Jump");
                First_Input = true;
            }
        }
        if (First_Input && !Anim.isPlaying)
        {
            Game_Start = true;
            Cam_Rel.Play("Cam_Init");
            First_Input = false;
            Txt_Score.SetActive(true);
            Invoke("Remove_TitleScreen", 1f);
        }

        if (!Game_Over && Game_Start)
            Check_Movement();
    }
    void Remove_TitleScreen()
    {
        Txt_Dino_Runner.SetActive(false);
    }


    void Check_Movement()
    {
        if(Anim.isPlaying == false)//is not in jump
        Model_Anim.Play("Run");
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && Position > 0 && Dino_Anim.isPlaying == false)
        {
            if (Position == 1)
            {
                Dino_Anim.Play("Move_Left");
                Cam_Abs.Play("Cam_Move_Right");
            }
            else if (Position == 2)
            {
                Dino_Anim.Play("Move_Center_From_Right");
                Cam_Abs.Play("Cam_Move_Center_From_Left");
            }
            Position--;
        }

         if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && Position < 2 && Dino_Anim.isPlaying == false)
            {
                if (Position == 0)
                {
                Dino_Anim.Play("Move_Center_From_Left");
                Cam_Abs.Play("Cam_Move_Center_From_Right");
            }
                else if (Position == 1)
                {
                Dino_Anim.Play("Move_Right");
                Cam_Abs.Play("Cam_Move_Left");
            }
                Position++;
            }

        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && Anim.isPlaying == false)
            {
            Anim.Play("Jump"); 
            }            
    }
    public static bool Game_Start = false;
    public static bool Game_Over = false;
    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Obstacle")
        {
            Game_Over = true;
            Cam_Rel.Play("Cam_Got_Hit");
            Sound_Game_Over_Play();
        }
    }

    void Sound_Jump_Play()
    {
        audio.clip = Sound_Jump;
        audio.Play(0);
    }
    void Sound_100pts_Play()
    {
        audio.clip = Sound_100pts;
        audio.Play(0);
    }
    void Sound_Game_Over_Play()
    {
        audio.clip = Sound_Game_Over;
        audio.Play(0);
    }
}
