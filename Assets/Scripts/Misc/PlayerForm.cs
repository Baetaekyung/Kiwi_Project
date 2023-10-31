using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForm : PlayerState
{
    [SerializeField]
    Sprite[] playerForms;

    private SpriteRenderer spriteRenderer;
    private Sprite playerCurrentForm;
    

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        playerCurrentForm = playerForms[0];
    }

    private void Update()
    {
        if(fightState == FightStates.Fighting)
        {
            spriteRenderer.sprite = playerCurrentForm;
        }
    }
}
