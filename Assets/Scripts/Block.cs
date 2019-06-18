using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Block : MonoBehaviour
{
    private int remainingHits = 5;

    private SpriteRenderer spriteRenderer;
    private TMPro.TextMeshPro text;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = GetComponentInChildren<TextMeshPro>();
        UpdateUI();
    }

    private void UpdateUI()
    {
        text.SetText(remainingHits.ToString());
        spriteRenderer.color = Color.Lerp(Color.white, Color.red, remainingHits / 10f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        remainingHits--;
        if (remainingHits > 0)
        {
            UpdateUI();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    internal void SetHits(int hits)
    {
        remainingHits = hits;
        UpdateUI();
    }
}
