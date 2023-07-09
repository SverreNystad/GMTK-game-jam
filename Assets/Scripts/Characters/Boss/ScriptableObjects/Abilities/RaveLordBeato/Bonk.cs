using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Bonk")]
public class Bonk : Ability
{
    [SerializeField] private GameObject bonkObjPrefab;
    [SerializeField] private float damage = 10.0f;
    [SerializeField] private float attackDuration = 0.1f;
    [SerializeField] private float spawnOffset = -1.0f;
    private GameObject spawnedBonkObj = default;
    private Animator animator = null;
    private float attackMultiplier = 1.0f;
    private bool shouldHaveStartedAnimation = false;
    private float bonkAttackLivedLength = 0.0f;
    private const float timeToWaitBeforeDamaging = 1.6f;
    private float waitedTime = 0.0f;
    
    public override void DoOnStart(Transform target)
    {
        if (attackDuration >= cooldown) {
            Debug.LogWarning("The bonk attack duration is more than the cooldown and can cause problems, therefore we are setting the attackduration to cooldown-0.1");
            attackDuration = cooldown-0.1f;
        }
        if (spawnedBonkObj == default) {
            spawnedBonkObj = Instantiate(bonkObjPrefab, new Vector2(0.0f, spawnOffset), Quaternion.identity, target);
            spawnedBonkObj.SetActive(false);
            if (spawnedBonkObj.GetComponent<AttackCallback>() == null) {
                Debug.LogWarning("The object does not have an attack callback and might not work as expected because the ability will never know if there is a collision");
            } else {
                spawnedBonkObj.GetComponent<AttackCallback>().SetCallbackFunction(CollisionCallback);
            }
        }
        if (animator == null) {
            if (target.GetComponent<Animator>() == null) {
                Debug.LogWarning("There is no animator! Should this be so?");
            } else {
                animator = target.GetComponent<Animator>();
            }
        }
    }

    private void CollisionCallback(Transform colliderTransform) {
        if (colliderTransform.tag == spawnedBonkObj.transform.parent.tag) return;
        if (colliderTransform.GetComponent<Health>() == null) {
            Debug.LogWarning("Collided with something that did not have an health component!");
            return;
        }
        colliderTransform.GetComponent<Health>().Damage(damage * attackMultiplier);
    }

    protected override void AddUpdateActions()
    {
        updateActions.Add(Attack);
    }

    private void Attack() {
        if (!shouldHaveStartedAnimation) return;
        waitedTime += Time.deltaTime;
        if (waitedTime < timeToWaitBeforeDamaging) return;
        if (spawnedBonkObj == null) return;
        if (!spawnedBonkObj.activeSelf) spawnedBonkObj.SetActive(true);
        bonkAttackLivedLength += Time.deltaTime;
        if (bonkAttackLivedLength < attackDuration) return;
        spawnedBonkObj.SetActive(false);
        waitedTime = 0.0f;
        bonkAttackLivedLength = 0.0f;
        shouldHaveStartedAnimation = false;
    }

    protected override void DoAction(Item[] items)
    {
        shouldHaveStartedAnimation = true;
        if (animator == null) {
            Debug.LogWarning("No animator was attached to the object at start, so skipping animation!");
            return;
        }
        animator.SetTrigger("ShouldBonk");
    }
}
