using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class FightHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D target;
    [SerializeField] private float range;
    // [SerializeField] private Ability[] abilities = new Ability[3];
    [SerializeField] private Ability attack;
    [SerializeField] private Ability heal;
    [SerializeField] private Ability rollback;
    [SerializeReference] private Item[] items;

    private string targetTag = "Boss";


    void Start()
    {
        // Get myself and my target
        this.rb = GetComponent<Rigidbody2D>();
        GameObject targetGO = GameObject.FindWithTag(targetTag);
        this.target = targetGO.GetComponent<Rigidbody2D>();
        attack.DoOnStart(transform);
        heal.DoOnStart(transform);
        rollback.DoOnStart(transform);
        // foreach(var ability in abilities) ability.DoOnStart(transform);
    }

    // Update is called once per frame
    void Update()
    {
        // foreach (var ability in abilities) ability.DoUpdate();
        attack.DoUpdate();
        heal.DoUpdate();
        rollback.DoUpdate();
        DoAbility();
    }


    public void DoAbility() 
    {
        Ability a = ChooseAbility();
        if (a == null) return;
        a.ActivateAbility(items);
    }

    private bool ShouldAttack()
    {
        float distance = Vector2.Distance(rb.position, target.position);
        return distance <= range && !attack.IsOnCooldown();
    }

    /// <sumamry>
    /// Take a random ability and return it
    /// </sumamry>
    private Ability ChooseAbility() 
    {
        if (ShouldAttack()) return attack;
        var healthComp = rb.GetComponent<Health>();
        if (healthComp.health == healthComp.maxHealth) return null;
        if (healthComp.health <= healthComp.maxHealth/2.0f && Vector2.Distance(rb.position, target.position) < (range + 1.0f)) return rollback;
        return heal; 
        // var random = new System.Random();
        // int chooseIndex = random.Next(0, 3);
        // return abilities[chooseIndex];
    }

}