using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/DrinkBeer")]
public class DrinkBeer : Ability
{
    [SerializeField] private float healingAmount;
    private Transform target;


    protected override void AddUpdateActions()
    {
        return;
    }

    public override void DoOnStart(Transform target)
    {
        this.target = target;
    }

    protected override void DoAction(Item[] items)
    {
        float itemsHealingMultiplier = 1.0f;
        foreach (var item in items)
        {
            if (item.type == EffectTypeMultiplier.HEALING) {
                itemsHealingMultiplier *= item.amount;
            }
        }
        DrinkBeerAbility(healingAmount * itemsHealingMultiplier);
    }

    /// <summary>
    /// This ability makes the player gain health
    /// </summary>
    private void DrinkBeerAbility(float amountToHeal) 
    {
        Health characterHealth = this.target.GetComponent<Health>();
        characterHealth.Heal(amountToHeal);
    }
}
