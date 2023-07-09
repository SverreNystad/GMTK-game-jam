using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [field: SerializeField] public float maxHealth {get; private set;}
    [SerializeField] private string healthBarTagName = "";
    public float health {get; private set;}
    HealthBar[] healthBar;

    void Start()
    {
        this.health = maxHealth;
    }

    public bool IsAlive() 
    {
        return health > 0;
    }

    public void Damage(float amount)
    {
        float newHealth = this.health - amount;

        if (newHealth < 0) {
            this.health = 0;
            return;
        }
        this.health = newHealth;

    }

    public void Heal(float amount)
    {
        float newHealth = this.health + amount;
        this.health = Mathf.Min(newHealth, maxHealth);
    }
}
