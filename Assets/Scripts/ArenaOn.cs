using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaOn : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    SpriteRenderer spriteRenderer;
    PlayerFighting pF;
    CompositeCollider2D compositcollider;

    float clampValueX = 0f;
    float clampValueY = 0f;
    float clampPosMinusX = 0;
    float clampPosMinusY = 0;
    float clampPosPlusX = 0;
    float clampPosPlusY = 0;

    private void Awake()
    {
        pF = FindObjectOfType<PlayerFighting>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        compositcollider = GetComponent<CompositeCollider2D>();
    }

    void Start()
    {
        spriteRenderer.enabled = false;
        compositcollider.enabled = false;
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
            compositcollider.enabled = true;
            //player.transform.position = SelectClampPos();
        }
        // Off
        if (pF.endFight)
        {
            spriteRenderer.enabled = false;
            compositcollider.enabled = false;
        }
    }

    //private Vector2 SelectClampPos()
    //{
    //    clampPosMinusX = transform.position.x - boxCollider.composite.bounds.extents.x;
    //    clampPosPlusX = transform.position.x + boxCollider.composite.bounds.extents.x;
    //    clampPosMinusY = transform.position.y - boxCollider.composite.bounds.extents.y;
    //    clampPosPlusY = transform.position.y + boxCollider.composite.bounds.extents.y;

    //    return new Vector2(Mathf.Clamp(clampValueX, clampPosMinusX, clampPosPlusX),
    //        Mathf.Clamp(clampValueY, clampPosMinusY, clampPosPlusY));
    //}
}
