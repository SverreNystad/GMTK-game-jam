using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubbleHandler : MonoBehaviour
{
    private SpriteRenderer backgroundSROuter;
    private SpriteRenderer backgroundSRInner;
    private SpriteRenderer iconSR;
    private TextMeshPro text;
    
    private void Awake()
    {
        backgroundSROuter = transform.Find("ChatBackgroundOuter").GetComponent<SpriteRenderer>();
        backgroundSRInner = transform.Find("ChatBackgroundInner").GetComponent<SpriteRenderer>();

        iconSR = transform.Find("Icon").GetComponent<SpriteRenderer>();
        text = transform.Find("ChatText").GetComponent<TextMeshPro>();
    }

    private void Setup(string newText)
    {
        text.SetText(newText);
        text.ForceMeshUpdate();
        Vector2 textSize = text.GetRenderedValues(false);
    }

    private void Start()
    {
        Setup("Hello World!");
    }
}
