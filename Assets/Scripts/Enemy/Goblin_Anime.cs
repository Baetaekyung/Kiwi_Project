using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goblin_Anime : MonoBehaviour
{
    [SerializeField] private WaitForSeconds attackWfs;
    [SerializeField] private float attackCooltime;
    Animator animator;
    Rigidbody2D rb;
    private bool isAttacking;

    private void Awake()
    {
        animator = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        attackWfs = new WaitForSeconds(attackCooltime);
    }

    private void Update()
    {
        animator.SetFloat("isMove", rb.velocity.magnitude);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (!isAttacking)
            {
                StartCoroutine("Attack");
            }
        }
    }
    IEnumerator Attack()
    {
        isAttacking = true;
        animator.SetTrigger("attack");
        yield return attackWfs;
        isAttacking = false;
    }
}
