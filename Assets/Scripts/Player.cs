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

    public AudioClip shootAudioClip;
    public AudioClip explotionAudioClip;


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
            Dead();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        Destroy(bullet, 2f);
        timeOfLastShoot = Time.time;

        AudioSource.PlayClipAtPoint(shootAudioClip, transform.position, 1f);
    }

    private void Dead()
    {
        AudioSource.PlayClipAtPoint(explotionAudioClip, transform.position, 5f);

        Instantiate(deathParticlePrefab, transform.position, transform.rotation);

        FindObjectOfType<GameManager>().GameOver();

        Destroy(this.gameObject);
    }
}
