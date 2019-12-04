using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice_RST : MonoBehaviour
{

    private float width;
    public string Reset_Tag = "";
    private float Time_Left_For_Next_Reset = 0f;//stops the trigger event from triggering twice a frame

    void Start()
    {
        width = GetComponent<Collider>().bounds.size.x;
        
    }
    void Update()
    {
        Time_Left_For_Next_Reset -= Time.deltaTime;
    }

        private void OnTriggerEnter(Collider col)
    {
        if (col.tag == Reset_Tag && Time_Left_For_Next_Reset < 0)
        {
            //Debug.Log(Vector3.left * (width * 2));
            Time_Left_For_Next_Reset = 3f;
            transform.position += Vector3.left*(width*2);           
        }
    }
}
