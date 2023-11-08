using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    PlayerInput inputs;
    Animator animator;

    private void Awake()
    {
        inputs = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerDieAnim();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Respawn();
        }
    }

    private void OnEnable()
    {
        inputs.onMovementChanged += AnimationPlayer;
    }

    private void OnDestroy()
    {
        inputs.onMovementChanged -= AnimationPlayer;
    }

    private void AnimationPlayer(Vector2 direction)
    {
        animator.SetFloat("velocity_x", direction.x);
        animator.SetFloat("velocity_y", direction.y);
    }

    private void PlayerDieAnim()
    {
        animator.SetTrigger("death");
    }

    private void Respawn()
    {
        animator.SetTrigger("respawn");
    }
}
