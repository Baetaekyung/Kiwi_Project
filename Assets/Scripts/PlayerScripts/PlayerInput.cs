using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Action<Vector2> onMovementChanged;
    public Action<Vector2> onDash;

    private float horizontal, vertical;
    public Vector3 moveDirection = Vector3.zero;

    private void Update()
    {
        MoveInput();
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
}
