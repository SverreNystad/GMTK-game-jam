using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/RollBackwards")]
[RequireComponent(typeof(IMovement))]
[RequireComponent(typeof(Rigidbody2D))]
public class RollBackwards : Ability
{
    private Rigidbody2D rb;
    private IMovement movement;
    
    protected override void DoAction(Item[] items)
    {
        // Move player in the opposite direction of the last movement input
        rb.position = rb.position - movement.GetLastDirection();
    }

    protected override void AddUpdateActions() 
    {
        
    }
    
    public override void DoOnStart(Transform target)
    {
        rb = target.GetComponent<Rigidbody2D>();
        movement = target.GetComponent<IMovement>();
    }
    
}
