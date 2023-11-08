using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushAtWall : MonoBehaviour
{
    public static Collision2D collisions;

    private void OnCollisionStay2D(Collision2D collision)
    {
        collisions = collision;
        Vector3 knockbackDir = Vector3.zero;
        knockbackDir = (collision.transform.position - transform.position).normalized;
        if (collision.transform.GetComponent<Rigidbody2D>())
        {
            collision.rigidbody.AddForce(knockbackDir, ForceMode2D.Force);
            Invoke("KnockbackStop", 0.2f);
        }
    }
    private void KnockbackStop()
    {
        collisions.rigidbody.velocity = Vector3.zero;
    }
}
