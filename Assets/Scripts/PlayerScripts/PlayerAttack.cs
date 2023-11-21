using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject hitParticle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.hp--;
            Instantiate(hitParticle, collision.transform.position, Quaternion.identity);
        }
    }
}
