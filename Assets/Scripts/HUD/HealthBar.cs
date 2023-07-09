using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public string tagToShowHealthFor = "";

    //private string targetTag = "Boss";
    [SerializeField] private Health target;

    void Start()
    {
        //this.target = GameObject.FindWithTag(targetTag).GetComponent<Health>();
        if (tagToShowHealthFor != "") target = GameObject.FindGameObjectWithTag(tagToShowHealthFor).GetComponent<Health>();
        SetMaxHealth((int)target.maxHealth);
    }
    

    void Update()
    {
        SetHealth((int)target.health);
    }

    public void SetMaxHealth(int max_health){
        slider.maxValue = max_health;
        slider.value = max_health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health){
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
