using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Obstacles = new GameObject[0];
    public float Spawn_Distance = 100f;
    public GameObject Dino;
    private Vector3 NextPosition;
    private float timeLeftForNextSpawn = 2f;
    public float SpawnTime = 2f;

    
    private void Start()
    {        
        Spawn();
    }
    void Update()
    {
        timeLeftForNextSpawn -= Time.deltaTime;
        if (timeLeftForNextSpawn <= 0 && !Player.Game_Over) Spawn();
    }
        public void Spawn()
    {
        Vector3 Position_Offset = new Vector3(Random.Range(-40, 40), 0, 0);
        int index = (int)Random.Range(0, Obstacles.Length);
        NextPosition = new Vector3(Dino.transform.position.x - Spawn_Distance , 0f, 0f);
        Instantiate(Obstacles[index], NextPosition + Position_Offset, Dino.transform.rotation);//obj pos rotation
        timeLeftForNextSpawn = SpawnTime;
    }
}
