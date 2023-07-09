using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/KatanaSlice")]
public class KatanaSlice : Ability
{
    [SerializeField] private GameObject katanaObjPrefab;
    [SerializeField] private float damage = 10.0f;
    [SerializeField] private float attackDuration = 0.5f;
    [SerializeField] private float spawnOffset = 1.0f;
    private GameObject spawnedKatanaObj = default;
    private IMovement movement = null;
    private float katanaLivedTime = 0.0f;
    private float attackMultiplier = 1.0f;

    protected override void AddUpdateActions()
    {
        updateActions.Add(UpdateKatanaAttack);
    }

    private void UpdateKatanaAttack() {
        if (!spawnedKatanaObj.activeSelf) return;
        katanaLivedTime += Time.deltaTime;
        
        if (movement != null) {
            spawnedKatanaObj.transform.rotation = Quaternion.identity;
            spawnedKatanaObj.transform.localPosition = movement.GetLastDirection().normalized*spawnOffset;
            float goingDown = Mathf.Sign(movement.GetLastDirection().y);
            spawnedKatanaObj.transform.localEulerAngles = new Vector3(0.0f, 0.0f, Vector2.Angle(Vector2.up, movement.GetLastDirection())*Mathf.Sign(-movement.GetLastDirection().x*goingDown)*Mathf.Sign(movement.GetLastDirection().y));
        }

        if (katanaLivedTime < attackDuration) return;
        katanaLivedTime = 0.0f;
        spawnedKatanaObj.SetActive(false); 
    }

    public bool IsKatanaActive() {
        return spawnedKatanaObj.activeSelf;
    }

    protected override void DoAction(Item[] items)
    {
        float multiplier = 1.0f;
        foreach (var item in items) 
        {
            if (item.type != EffectTypeMultiplier.DAMAGE) continue;
            multiplier *= item.amount;
        }
        attackMultiplier = multiplier;
        spawnedKatanaObj.SetActive(true);
    }

    private void CollisionCallback(Transform colliderTransform, Transform attackTransform) {
        if (colliderTransform.tag == spawnedKatanaObj.transform.parent.tag) return;
        if (colliderTransform.GetComponent<Health>() == null) {
            Debug.LogWarning("Collided with something that did not have an health component!");
            return;
        }
        colliderTransform.GetComponent<Health>().Damage(damage * attackMultiplier);
    }

    public override void DoOnStart(Transform target)
    {
        if (attackDuration >= cooldown) {
            Debug.LogWarning("The kantana attack duration is more than the cooldown and can cause problems, therefore we are setting the attackduration to cooldown-0.1");
            attackDuration = cooldown-0.1f;
        }
        if (spawnedKatanaObj == default) {
            spawnedKatanaObj = Instantiate(katanaObjPrefab, new Vector2(0.0f, spawnOffset), Quaternion.identity, target);
            spawnedKatanaObj.SetActive(false);
            if (spawnedKatanaObj.GetComponent<AttackCallback>() == null) {
                Debug.LogWarning("The object does not have an attack callback and might not work as expected because the ability will never know if there is a collision");
            } else {
                spawnedKatanaObj.GetComponent<AttackCallback>().SetCallbackFunction(CollisionCallback);
            }
        }
        IMovement movementScript = target.GetComponent<IMovement>();
        if (movementScript != null) movement = movementScript;
    }

}
