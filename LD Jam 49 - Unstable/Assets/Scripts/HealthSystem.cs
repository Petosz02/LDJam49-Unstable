using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;
    private bool isDead;

    public int CurrentHealth { get => currentHealth; private set => currentHealth = value; }



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
    }

    public bool Damage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            isDead = true;
        }

        return isDead;
    }
}
