using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed;

    PlayerInput inputs;
    Rigidbody2D myRigid;

    private void Awake()
    {
        inputs = GetComponent<PlayerInput>();
        myRigid = GetComponent<Rigidbody2D>();  
    }

    private void OnEnable()
    {
        inputs.onMovementChanged += PlayerMovement;
    }

    private void OnDestroy()
    {
        inputs.onMovementChanged -= PlayerMovement;
    }

    private void PlayerMovement(Vector2 direction)
    {
        myRigid.velocity = direction * playerMoveSpeed;
    }
}
