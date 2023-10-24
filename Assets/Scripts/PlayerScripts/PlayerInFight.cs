using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInFight : MonoBehaviour
{
    public bool isFighting = false;

    private Vector3 mouseDirection = Vector3.zero;
    private Vector3 mouseInputVector = Vector3.zero;

    private void Update()
    {
        MouseInput();
    }

    private void MouseInput()
    {
        if (!isFighting)
        {
            return;
        }       
        mouseInputVector = Camera.main.
            ScreenToWorldPoint(Input.mousePosition);
        mouseInputVector = mouseInputVector.normalized;
        mouseDirection = mouseInputVector;
        MoveToMousePos(mouseDirection);
    }

    private void MoveToMousePos(Vector3 mouseDir)
    {
        transform.position = mouseDir * Time.deltaTime * 10f;
    }
}
