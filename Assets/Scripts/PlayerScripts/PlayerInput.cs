using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Action<Vector2> onMovementChanged;

    PlayerFighting pF;

    private float horizontal, vertical;
    private Vector3 moveDirection = Vector3.zero;

    private void Awake()
    {
        pF = GetComponent<PlayerFighting>();
    }

    private void Update()
    {
        if (pF.cantMove)
        {
            return;
        }
        InputSystem();
    }

   private void InputSystem()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontal, vertical, 0).normalized;
        onMovementChanged?.Invoke(moveDirection);
    }
}
