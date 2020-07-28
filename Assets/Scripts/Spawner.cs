using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float timeBetweenSpawns = 1f;


    float bottomLimit;
    float topLimit;
    float rightLimit;
    float leftLimit;

    private void Start()
    {


        SpriteRenderer renderer = GetComponent<SpriteRenderer>();


        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(Vector3.zero);
        bottomLimit = bottomLeft.y;
        leftLimit = bottomLeft.x;

        Vector3 topRight = Camera.main.ViewportToWorldPoint(Vector3.one);
        topLimit = topRight.y;
        rightLimit = topRight.x;


        //leftLimit += renderer.bounds.extents.y;
        //rightLimit += renderer.bounds.extents.y;

        InvokeRepeating("Spawn", 1f, timeBetweenSpawns);
    }


    void Spawn()
    {

        float x = Random.Range(leftLimit, rightLimit);
        Vector3 position = new Vector3(x, topLimit + 1f, 0f);
        //position.y = Random.Range(3f, 4f);
        //position.x = Random.Range(-6f, 6f);

        int random = Random.Range(0, prefabs.Length);

        Instantiate(prefabs[random], position, Quaternion.identity);
    }

    private void FixedUpdate()
    {

        Vector3 desiredPosition = transform.position * Time.fixedDeltaTime;

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, leftLimit, rightLimit);
    }
}
