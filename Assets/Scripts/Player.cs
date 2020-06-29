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
            Debug.Log("Game Over");
            Destroy(this.gameObject);
        }
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        timeOfLastShoot = Time.time;
    }
}
