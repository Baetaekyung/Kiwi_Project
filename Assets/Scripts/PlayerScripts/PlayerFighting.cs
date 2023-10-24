using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighting : MonoBehaviour
{
    [SerializeField]
    GameObject fightingSquare;
    [SerializeField]
    Sprite changeForm;

    float timer = 1f;
    float moveTimer = 2.5f;

    public bool cantMove = false;
    public bool isFighting = false;
    public bool endFight = false;

    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isFighting)
        {
            ChangeForm();
        }
    }

    private void ChangeForm()
    {
        StartCoroutine(TimerToMove());
        transform.position = Vector3.Lerp(transform.position, fightingSquare.transform.position,
                Time.deltaTime / timer);
    }

    IEnumerator TimerToMove()
    {
        cantMove = true;
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(moveTimer);
        cantMove = false;
        isFighting = true;
    }
}
