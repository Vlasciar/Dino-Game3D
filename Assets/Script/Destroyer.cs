using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float TimeToDestroy;
    private void Start()
    {
        DestroyObjectDelayed();
    }
    void DestroyObjectDelayed()
    {
        Destroy(gameObject, TimeToDestroy);
    }
}
