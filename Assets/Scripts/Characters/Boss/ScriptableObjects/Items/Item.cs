using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] public EffectTypeMultiplier type {get; private set;}
    [SerializeField] public float amount {get; private set;}




}
