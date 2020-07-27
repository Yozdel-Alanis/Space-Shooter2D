using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float maxHP = 100f;
    public float timeBetweenShoots = 0.5f;

    public GameObject bulletPrefab;
    public Transform bulletOrigin;

    private float currentHP;
    private float timeOfLastShoot;

    public Text HP;

    public GameObject deathParticlePrefab;


    private void Start()
    {
        currentHP = maxHP;
        HP.text = "HP " + currentHP;

    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > timeOfLastShoot + timeBetweenShoots)
            {
            Shoot();
            }
        }
    }

    public void Damage(float amount)
    {
        currentHP -= amount;
        HP.text = "HP " + currentHP;

        if(currentHP <= 0f)
        {
            Instantiate(deathParticlePrefab, transform.position, transform.rotation);
            Debug.Log("Game Over");
            Destroy(this.gameObject);
        }
    }

    private void Shoot()
    {
        GameObject particles = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        Destroy(particles, 2f);
        timeOfLastShoot = Time.time;
    }
}
