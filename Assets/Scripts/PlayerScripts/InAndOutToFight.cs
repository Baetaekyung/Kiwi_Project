using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class InAndOutToFight : PlayerState
{
    [SerializeField]
    GameObject currentMap;
    [SerializeField]
    Collider2D currentMapConfiner;
    [SerializeField]
    Collider2D battleConfiner;
    [SerializeField]
    CinemachineVirtualCamera virtualCam;

    CinemachineConfiner2D currentConfiner;

    PlayerFighting playerFighting;
    PlayerAnimations animations;
    Animator animator;

    public Vector3 playersLastPos = Vector3.zero;

    private void Awake()
    {
        playerFighting = GetComponent<PlayerFighting>();
        animations = GetComponent<PlayerAnimations>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        battleConfiner.enabled = false;
        currentConfiner = virtualCam.GetComponent<CinemachineConfiner2D>();
    }

    private void Update()
    {
        if (playerFighting.endFight)
        {
            battleConfiner.enabled = false;
            currentMapConfiner.enabled = true;
            currentConfiner.m_BoundingShape2D = currentMapConfiner;
            currentMap.SetActive(true);
            fightState = FightStates.Roaming;
            transform.localScale = Vector3.one;
            transform.position = playersLastPos;
            animator.enabled = true;
            animations.enabled = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy") && fightState == FightStates.Roaming)
        {
            playersLastPos = collision.transform.position;
            collision.transform.GetComponent<CircleCollider2D>().enabled = false;
            fightState = FightStates.Fighting;
            battleConfiner.enabled = true;
            currentMapConfiner.enabled = false;
            currentConfiner.m_BoundingShape2D = battleConfiner;
            transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(0.6f, 0.6f, 1f), 1);
            currentMap.SetActive(false);
            animations.enabled = false;
            animator.enabled = false;
        } 
    }
}
