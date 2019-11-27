using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice_RST : MonoBehaviour
{
    public GameObject sample;
    private float width;
    public int size=20;
    void Start()
    {
        width = sample.GetComponent<MeshFilter>().mesh.bounds.extents.x*size;
    }


    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("new");
        if (col.tag == "Reset_Ground")
        {
            transform.position += Vector3.left*(width*6);
            
        }
    }
}
