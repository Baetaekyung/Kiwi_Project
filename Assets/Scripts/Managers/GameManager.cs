using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PlayerController currentPlayer;

    private void Awake()
    {
        currentPlayer = FindObjectOfType<PlayerController>();
    }
}
