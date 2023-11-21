using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Singleton<PlayerHealth>
{
    private Image healthBarImage = null;
    [SerializeField] Sprite[] sourceImage = null;
    [SerializeField] Sprite emptyHpBar;
    private GameManager gm;
    Player p;

    private void Awake()
    {
        gm = GameManager.Instance;
        healthBarImage = GetComponent<Image>();
        p = GameObject.Find("Player").GetComponent<Player>();
    }

    public void PlayerHit()
    {
        gm.PlayerHp--;
        StartCoroutine(p.InvisibleRoutine());
        CheckHp();
    }

    private void CheckHp()
    {
        healthBarImage.sprite = sourceImage[gm.PlayerHp];
        Debug.Log(gm.PlayerHp);
    }
}
