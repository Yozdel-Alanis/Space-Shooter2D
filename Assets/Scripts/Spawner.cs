using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;

    private void Start()
    {
        InvokeRepeating("Spawn", 1f, 1f);
    }
    void Spawn()
    {
        Vector3 position = new Vector3(0f, 0f, 0f);
        position.y = Random.Range(3f, 4f);
        position.x = Random.Range(-6f, 6f);
        Instantiate(prefab, position, Quaternion.identity);
    }
}
