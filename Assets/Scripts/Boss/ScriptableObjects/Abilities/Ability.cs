using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Ability : ScriptableObject
{
    [SerializeField] private float cooldown = 1.0f;
    private float remainingCooldown = 0.0f;

    protected List<Action> updateActions = new List<Action>();
    

    /// <summary>
    /// Shall make the ability do its effect and change the player character and or enemy character. 
    /// </summary>
    public abstract void ActivateAbility(Item[] items);
    
    protected abstract void AddUpdateActions();

    public bool CanActivateAbility() {
        return remainingCooldown <= 0.0;
    }


    private void StartCooldown(Item[] items) {
        float multiplier = 1.0f;
        foreach (var item in items) {
            if (item.type != AffectsType.COOLDOWN) continue;
            multiplier *= item.amount;
        }
        remainingCooldown = cooldown * multiplier;
    }

    /// <summary>
    /// Shall decrease the remaining time of the cooldown
    /// </summary>
    protected void UpdateCooldown(float deltaTime)
    {
        if (remainingCooldown <= 0.0) return;
        remainingCooldown -= deltaTime;
    }

    public void DoUpdate()
    {
        if (updateActions.Count == 0) AddUpdateActions();
        
        UpdateCooldown(Time.deltaTime);
        foreach (Action actionToDo in updateActions) actionToDo();
    }
}
