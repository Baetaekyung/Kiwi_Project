using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private float shieldCoolTime = 5f;
    [SerializeField] private GameObject col;
    private bool canAttack = false;
    private bool canShield = false;

    WaitForSeconds shieldWfs;

    PlayerInput inputs;
    Animator animator;

    private void Awake()
    {
        inputs = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();       
    }
    private void Start()
    {
        canAttack = true;
        canShield = true;
        shieldWfs = new WaitForSeconds(shieldCoolTime);
        col.SetActive(false);
    }

    private void OnEnable()
    {
        inputs.onMovementChanged += AnimationPlayer;
        inputs.onAttack += PlayerAttack;
        inputs.onShield += PlayerShield;
    }

    private void OnDestroy()
    {
        inputs.onMovementChanged -= AnimationPlayer;
        inputs.onAttack -= PlayerAttack;
        inputs.onShield -= PlayerShield;
    }

    private void AnimationPlayer(Vector2 direction)
    {
        animator.SetFloat("ismove", direction.magnitude);
    }
    private void PlayerAttack()
    {
        if (canAttack)
        {
            animator.SetTrigger("attack");
            canAttack = false;
        }
    }

    private void PlayerShield()
    {
        if (canShield)
        {
            animator.SetTrigger("shield");
            StartCoroutine("ShieldCoolTime");
            canShield = false;
        }
    }

    public void AttackEndEvent()
    {
        canAttack = true;
        col.SetActive(false);
    }
    public void AttackStartEvent()
    {
        col.SetActive(true);
    }

    IEnumerator ShieldCoolTime()
    {
        yield return shieldWfs;
        canShield = true;
    }
}
