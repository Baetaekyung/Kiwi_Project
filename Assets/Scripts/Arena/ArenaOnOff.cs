using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaOnOff : MonoBehaviour
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
        // On
        if (pF.isFighting)
        {
            spriteRenderer.enabled = true;
            boxCollider.enabled = true;
        }
        // Off
        if (pF.endFight)
        {
            StartCoroutine(EndFight());
        }
    }

    IEnumerator EndFight()
    {
        boxCollider.enabled = false;
        yield return new WaitForSeconds(1f);
        spriteRenderer.enabled = false;
        pF.isFighting = false;
        pF.endFight = false;
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
