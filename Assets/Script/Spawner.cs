using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Obstacles = new GameObject[0];
    public GameObject Dino;
    private float timeLeftForNextSpawn = 2f;
    public float SpawnTime = 2f;

    
    private void Start()
    {        
    }
    void Update()
    {
        timeLeftForNextSpawn -= Time.deltaTime;
        if (timeLeftForNextSpawn <= 0 && !Player.Game_Over && Player.Game_Start) Spawn();
    }
        public void Spawn()
    {
        Vector3 Position_Offset = new Vector3(Random.Range(-15, 15), 0, 0);
        int index = (int)Random.Range(0, Obstacles.Length); 
        Instantiate(Obstacles[index], transform.position + Position_Offset, Dino.transform.rotation);//obj pos rotation
        timeLeftForNextSpawn = SpawnTime;
    }
}
