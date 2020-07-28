using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHP = 30f;

    public float speed = 5f;
    public float timeBetweenShoots = 0.5f;
    public GameObject bulletPrefab;
    public Transform bulletOrigin;

    private float timeOfLastShoot;
    private Rigidbody2D rb;

    private float currentHP;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * speed;

        currentHP = maxHP;
    }

    private void Update()
    {
        if (Time.time > timeOfLastShoot + timeBetweenShoots)
            Shoot();
    }



    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        Destroy(bullet, 4f);
        timeOfLastShoot = Time.time;
    }

    public void Damage(float amount)
    {
        currentHP -= amount;

        if (currentHP <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
