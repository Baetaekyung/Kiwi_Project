using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goblin_Attack : MonoBehaviour
{
    [SerializeField] private WaitForSeconds attackWfs;
    [SerializeField] private float attackCooltime;
    Animator animator;

    private void Awake()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        attackWfs = new WaitForSeconds(attackCooltime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Attack();
    }
    IEnumerator Attack()
    {
        yield return attackWfs;
        animator.SetTrigger("attack");
    }
}
