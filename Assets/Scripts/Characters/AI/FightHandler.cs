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
    [SerializeField] private Ability[] abilities = new Ability[3];
    [SerializeReference] private Item[] items;

    private string targetTag = "Boss";


    void Start()
    {
        // Get myself and my target
        this.rb = GetComponent<Rigidbody2D>();
        GameObject targetGO = GameObject.FindWithTag(targetTag);
        this.target = targetGO.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var ability in abilities) ability.DoUpdate();
        attack();
    }


    public void attack() 
    {
        if (shouldAttack()) {
            Ability a = chooseAbility();
            a.ActivateAbility(items);
        }
    }

    private bool shouldAttack()
    {
        float distance = Vector2.Distance(rb.position, target.position);
        return range <= distance;
    }

    /// <sumamry>
    /// Take a random ability and return it
    /// </sumamry>
    private Ability chooseAbility() 
    {
        var random = new System.Random();
        int chooseIndex = random.Next(0, 3);
        return abilities[chooseIndex];
    }

}
