﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;


    float bottomLimit;
    float topLimit;
    float rightLimit;
    float leftLimit;

    private void Start()
    {
        //InvokeRepeating("Spawn", 1f, 1f);


        SpriteRenderer render = GetComponent<SpriteRenderer>();


        leftLimit += render.bounds.extents.y;
        rightLimit += render.bounds.extents.y;
    }
    void Spawn()
    {
        
        
        //Vector3 position = new Vector3(0f, 0f, 0f);
        //position.y = Random.Range(3f, 4f);
        //position.x = Random.Range(-6f, 6f);

        //int random = Random.Range(0, prefabs.Length);

        //Instantiate(prefabs[random], position, Quaternion.identity);
    }
}
