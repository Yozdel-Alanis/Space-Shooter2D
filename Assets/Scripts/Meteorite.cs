﻿using UnityEngine;



public class Meteorite : MonoBehaviour
{
    public float speed = 5f;
    public float damageAmount = 50;

    public GameObject particlePrefab;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                player.Damage(damageAmount);
                DestroyMeteorite();
            }
        }
    }

    public void DestroyMeteorite()
    {
        GameObject particles = Instantiate(particlePrefab, transform.position, transform.rotation);
        Destroy(particles, 2f);
        Destroy(this.gameObject);

    }
}
