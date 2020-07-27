using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP = 100f;


    public float timeBetweenShoots = 0.5f;

    public GameObject EBulletPrefab;
    public Transform EBulletOrigin;

    private float currentHP;
    private float timeOfLastShoot;

    public float speed = 5f;
    public float damageAmount = 10f;

    public GameObject hitParticleEnemy;

    private Rigidbody2D rb;

    private void Start()
    {
        InvokeRepeating("Spawn", 1f, 1f);

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;
    }

    private void Update()
    {
        if (Time.time > timeOfLastShoot + timeBetweenShoots)
        {
            Shoot();
        }
    }

    public void Damage(float amount)
    {
        currentHP -= amount;

        if (currentHP <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void Shoot()
    {
        Instantiate(EBulletPrefab, EBulletOrigin.position, EBulletOrigin.rotation);
        timeOfLastShoot = Time.time;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                player.Damage(damageAmount);
            }
        }

        GameObject particles = Instantiate(hitParticleEnemy, transform.position, transform.rotation);
        Destroy(particles, 2f);
        Destroy(this.gameObject);
    }

}
