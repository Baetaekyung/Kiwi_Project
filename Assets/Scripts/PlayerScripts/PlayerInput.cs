using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Action<Vector2> onMovementChanged;
    public Action<Vector3> onMouseDirectionChanged;
    public Action<Vector2> onDash;
    public Action onAttack;
    public Action onShield;

    private float horizontal, vertical;
    public Vector3 moveDirection = Vector3.zero;
    public Vector3 mouseDirection = Vector3.zero;

    private void Update()
    {
        MoveInput();
        MouseDirInput();
        AttackInput();
        ShieldInput();
    }

   private void MoveInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontal, vertical, 0).normalized;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            onDash?.Invoke(moveDirection);
        }
        onMovementChanged?.Invoke(moveDirection);
    }

    private void MouseDirInput()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseDirection = (mousePos - transform.position).normalized;
        onMouseDirectionChanged?.Invoke(mouseDirection);
    }

    private void AttackInput()
    {
        if (Input.GetMouseButton(0))
        {
            onAttack?.Invoke();
        }
    }

    private void ShieldInput()
    {
        if (Input.GetMouseButtonDown(1))
        {
            onShield?.Invoke();
        }
    }
}

