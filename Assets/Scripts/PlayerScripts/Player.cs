using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float invisibleT;
    WaitForSeconds invisibleTime;

    private void Awake()
    {
        invisibleTime = new WaitForSeconds(invisibleT);
    }

    private void Start()
    {
        invisibleTime = new WaitForSeconds(invisibleT);
    }

    public IEnumerator InvisibleRoutine()
    {
        GameManager.Instance.isInvisible = 1;
        yield return invisibleTime;
        GameManager.Instance.isInvisible = 0;
    }
}