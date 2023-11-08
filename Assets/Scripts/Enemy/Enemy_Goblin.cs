using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Goblin : Enemy
{
    SpriteRenderer sp;
    Rigidbody2D rb;
    WaitForSeconds dirWfs;
    int r, u;
    private void Awake()
    {
        sp = this.gameObject.GetComponent<SpriteRenderer>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        dirWfs = new WaitForSeconds(0.8f);
    }

    public void IsHit(int damage)
    {
        if(hp <= 0)
        {
            Death();
        }
        hp -= damage;
    }
    private void Death()
    {
        Destroy(gameObject);
        isDead = true;
    }
    private void Update()
    {
        if (!playerFind)
        {
            StartCoroutine(FindDir());
            Ai((speed * 0.9f), rb, r, u);
        }
    }
    IEnumerator FindDir()
    {
        r = Random.Range(0, 2);
        u = Random.Range(0, 2);
        yield return dirWfs;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindPlayer(collision.transform, rb);
            if (collision.transform.position.x > transform.position.x)
            {
                sp.flipX = false;
            }
            else
            {
                sp.flipX = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerFind = false;
    }
}
