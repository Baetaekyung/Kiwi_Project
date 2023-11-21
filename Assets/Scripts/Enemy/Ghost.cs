using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

public class Ghost : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private float currentSpeed;
    private Light2D light2d;
    private Vector3 moveDir;

    private void OnEnable()
    {
        player = FindAnyObjectByType<Player>().gameObject;
    }

    private void Update()
    {
        moveDir = player.transform.position - transform.position;
        moveDir = moveDir.normalized;
        transform.position += moveDir * currentSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            light2d = collision.GetComponentInChildren<Light2D>();
            light2d.intensity -= 0.2f;
            Release();
        }
    }

    private void Release()
    {
        transform.position = player.transform.position * 5f;
    }
}
