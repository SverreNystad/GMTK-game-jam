using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Ability : ScriptableObject
{
    [field: SerializeField] public float cooldown {get; private set;}
    private float remainingCooldown = 0.0f;

    protected List<Action> updateActions = new List<Action>();
    

    /// <summary>
    /// Shall make the ability do its effect and change the player character and or enemy character. 
    /// </summary>
    public void ActivateAbility(Item[] items) {
        if (!CanActivateAbility()) return;
        DoAction(items);
        StartCooldown(items);
    }
    
    protected abstract void DoAction(Item[] items);

    /// <summary>
    /// Shall add all the functions that should be ran for every frame (like in the Update method). So add functions to updateActions.
    /// </summary>
    protected abstract void AddUpdateActions();

    /// <summary>
    /// Shall do everything that needs to be done on Start.
    /// </summary>
    public abstract void DoOnStart(Transform target);

    public bool CanActivateAbility() {
        return remainingCooldown <= 0.0;
    }


    private void StartCooldown(Item[] items) {
        float multiplier = 1.0f;
        foreach (var item in items) {
            if (item.type != EffectTypeMultiplier.COOLDOWN) continue;
            multiplier *= item.amount;
        }
        remainingCooldown = cooldown * multiplier;
    }

    /// <summary>
    /// Shall decrease the remaining time of the cooldown
    /// </summary>
    protected void UpdateCooldown(float deltaTime)
    {
        if (!IsOnCooldown()) return;
        remainingCooldown -= deltaTime;
    }

    public void DoUpdate()
    {
        if (updateActions.Count == 0) AddUpdateActions();
        
        UpdateCooldown(Time.deltaTime);
        foreach (Action actionToDo in updateActions) actionToDo();
    }

    public bool IsOnCooldown() {
        return remainingCooldown > 0.0;
    }
}
