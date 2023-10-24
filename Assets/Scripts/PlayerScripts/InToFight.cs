using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class InToFight : PlayerState
{
    public States state;
    PlayerFighting playerFighting;
    private void Awake()
    {
        playerFighting = GetComponent<PlayerFighting>();
        state = States.roaming;
    }

    private void Start()
    {
        playerFighting.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        state = States.fighting;
        playerFighting.enabled = true;
    }
}
