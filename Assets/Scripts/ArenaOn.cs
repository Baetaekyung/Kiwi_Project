using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaOn : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    SpriteRenderer spriteRenderer;
    PlayerFighting pF;
    Collider2D boxCollider;

    Vector3 lastPos = Vector3.zero;

    private void Awake()
    {
        pF = FindObjectOfType<PlayerFighting>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<Collider2D>();
    }

    void Start()
    {
        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
    }

    void Update()
    {
        OnOff();
    }

    void OnOff()
    {
        if (!pF)
        {
            return;
        }
        // On
        if (pF.isFighting)
        {
            spriteRenderer.enabled = true;
            boxCollider.enabled = true;
            //player.transform.position = SelectClampPos();
        }
        // Off
        if (pF.endFight)
        {
            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            lastPos = other.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.position = lastPos;
        }
    }
}
