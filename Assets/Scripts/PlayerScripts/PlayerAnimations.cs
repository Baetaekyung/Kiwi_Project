using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private float shieldCoolTime = 5f;
    [SerializeField] private float InvisibleTime = 1.5f;
    [SerializeField] private GameObject col;
    [SerializeField] private bool canAttack = false;
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
            GameManager.Instance.isInvisible = 1;
            StartCoroutine(InvisibleRoutine());
            StartCoroutine("ShieldCoolTime");
            canShield = false;
        }
    }

    private void Update()
    {
        StartCoroutine(AttackCoolTime());
    }

    IEnumerator InvisibleRoutine()
    {
        yield return new WaitForSeconds(InvisibleTime);
        GameManager.Instance.isInvisible = 0;
    }

    public void AttackEndEvent()
    {
        animator.SetTrigger("attackFin");
        col.SetActive(false);
    }
    public void AttackStartEvent()
    {
        col.SetActive(true);
    }
    public void ShieldFinEvent()
    {
        animator.SetTrigger("shieldFin");
    }
    IEnumerator ShieldCoolTime()
    {
        yield return shieldWfs;
        canShield = true;
    }
    IEnumerator AttackCoolTime()
    {
        if (!canAttack)
        {
            yield return new WaitForSeconds(0.3f);
            canAttack = true;
        }
    }
}
