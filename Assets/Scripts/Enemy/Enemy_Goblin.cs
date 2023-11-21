using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Enemy_Goblin : Enemy
{
    [SerializeField] Vector3 monsterScale;
    [SerializeField] Vector3 flipScale;
    Rigidbody2D rb;
    WaitForSeconds dirWfs;

    int r, u;
    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        dirWfs = new WaitForSeconds(0.8f);
    }

    private void Death()
    {
        if(hp <= 0)
        {
            Destroy(gameObject);
            isDead = true;
        }
    }

    public void AttackEvent()
    {
        Collider2D hitBox = Physics2D.OverlapBox(transform.position, Vector2.one, LayerMask.GetMask("HitBox"));
        if (hitBox && GameManager.Instance.isInvisible == 0)
        {
            PlayerHealth.Instance.PlayerHit();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, Vector2.one);
    }
    private void Update()
    {
        if (!playerFind)
        {
            StartCoroutine(FindDir());
            Ai((speed * 0.9f), rb, r, u);
        }
        Death();
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
                transform.localScale = monsterScale;
            }
            else
            {
                transform.localScale = flipScale;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerFind = false;
    }
}
