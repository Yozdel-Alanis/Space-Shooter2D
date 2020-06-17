using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHP = 100f;

    private float currentHP;

    private void Start()
    {
        currentHP = maxHP;
    }

    public void Damage(float amount)
    {
        currentHP -= amount;

        if(currentHP <= 0f)
        {
            Debug.Log("Game Over");
            Destroy(this.gameObject);
        }
    }
}
