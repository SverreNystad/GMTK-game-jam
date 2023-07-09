using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class AttackCallback : MonoBehaviour
{
    private Action<Transform, Transform> callback = default;

    public void SetCallbackFunction(Action<Transform, Transform> function) {
        callback = function;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (callback == default) {
            Debug.LogWarning("The callback function was default, so no callback was set on the weapon");
            return;
        }
        callback(collision.transform, transform);
    }
    
}
