using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/RollBackwards")]
public class RollBackwards : Ability
{
    
    public override void ActivateAbility(Item[] items)
    {
        throw new System.NotImplementedException();
    }

    protected override void AddUpdateActions() 
    {
        updateActions.Add(HellYeah);
    }

    private void HellYeah() {
        Debug.Log("HELLLYEAHHH");
    }

}
