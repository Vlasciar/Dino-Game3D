using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Obstacles = new GameObject[0];
    public float Spawn_Distance = 300f;
    public GameObject Dino;
    private Vector3 NextPosition;
    private float timeLeftForNextSpawn = 3f;

    
    private void Start()
    {
        
        Spawn();
    }
    void Update()
    {
        timeLeftForNextSpawn -= Time.deltaTime;
        if (timeLeftForNextSpawn <= 0) Spawn();
    }
        public void Spawn()
    {
        Vector3 Position_Offset = new Vector3(Random.Range(-20, 20), 0, 0);
        int index = (int)Random.Range(1, Obstacles.Length);
        NextPosition = new Vector3(Dino.transform.position.x - Spawn_Distance , 0f, 0f);
        Instantiate(Obstacles[index], NextPosition + Position_Offset, Dino.transform.rotation);//obj pos rotation
        timeLeftForNextSpawn = 3f;
    }
}
