using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] public AffectsType type {get; private set;}
    [SerializeField] public float amount {get; private set;}




}
