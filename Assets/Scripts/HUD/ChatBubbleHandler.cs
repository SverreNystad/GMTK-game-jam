using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubbleHandler : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    private float remainingCooldown = 0.0f;

    

    public void SetText(string newText, float showTime=3)
    {
        text.SetText(newText);
        text.ForceMeshUpdate();
        Vector2 textSize = text.GetRenderedValues(false);
        remainingCooldown = showTime;
    }

    /// <summary>
    /// Shall decrease the remaining time of the cooldown
    /// </summary>
    private void UpdateCooldown(float deltaTime)
    {
        if (remainingCooldown <= 0.0) return;
        remainingCooldown -= deltaTime;
    }


    private void Start()
    {
        SetText("Finally a hero i can beat",5);
    }

    private void Update()
    {
        UpdateCooldown(Time.deltaTime);
        if (remainingCooldown <= 0.0) {
            SetText("");
        }
    }


}
