using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    [SerializeField] public int MAX_HEALTH {get; private set;}
    public int health {get; private set;}

    void Start()
    {
        this.health = MAX_HEALTH;
    }

    public bool IsAlive() 
    {
        return health > 0;
    }

    public void Damage(int amount)
    {
        int newHealth = this.health - amount;
        if (newHealth < 0) {
            this.health = 0;
            return;
        }
        this.health = newHealth;
    }

    public void Heal(int amount)
    {
        int newHealth = this.health - amount;
        if (newHealth >= MAX_HEALTH) {
            this.health = MAX_HEALTH;
            return;
        }
        this.health = newHealth;
    }
}
