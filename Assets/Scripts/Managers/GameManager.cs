using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public PlayerController currentPlayer;
    public GameObject hitBox;
    public int isInvisible = 0;
    private int playerHp;
    public int PlayerHp
    {
        get => playerHp;
        set => playerHp = Mathf.Clamp(value, 0, 5);
    }

    private void Awake()
    {
        currentPlayer = FindObjectOfType<PlayerController>();
        playerHp = 5;
    }
}
