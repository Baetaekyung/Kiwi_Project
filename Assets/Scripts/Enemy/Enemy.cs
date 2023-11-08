using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public float speed;
    public bool isDead = false;
    public bool playerFind = false;
    public Vector2 dirVec;

    public void Ai(float speed, Rigidbody2D rigid, int r, int u)
    {
        if(isDead)
        {
            return;
        }
        if(r == 0)
        {
            dirVec += Vector2.right;
        }
        else if(r == 1)
        {
            dirVec += Vector2.left;
        }
        if(u == 0)
        {
            dirVec += Vector2.up;
        }
        else if (u == 1)
        {
            dirVec += Vector2.down;
        }
        rigid.velocity = dirVec.normalized * speed;
    }

    public void FindPlayer(Transform playerTransform, Rigidbody2D rigid)
    {
        playerFind = true;
        Vector3 dir = (playerTransform.position - transform.position).normalized;
        rigid.velocity = dir * speed;
    }
}
