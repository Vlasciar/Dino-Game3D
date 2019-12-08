using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float TimeToDestroy;
    private void Start()
    {
            Invoke("DestroyMe", TimeToDestroy);       
    }
    private void Update()
    {
        if(Player.Game_Over)
        {
            CancelInvoke("DestroyMe");
        }
    }
     void DestroyMe()
    {
        Destroy(gameObject);
    }
}
