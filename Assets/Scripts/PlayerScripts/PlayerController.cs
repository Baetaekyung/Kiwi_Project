using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashCooltime;
    [SerializeField] private float invisibleTime;
    [SerializeField] Collider2D myCol;

    Vector3 pMinusScale;
    public bool canDash;
    private WaitForSeconds dashWfs;
    private WaitForSeconds invisibleWfs;

    PlayerInput inputs;
    Rigidbody2D myRigid;

    private void Awake()
    {
        inputs = GetComponent<PlayerInput>();
        myRigid = GetComponent<Rigidbody2D>();  
    }

    private void Start()
    {
        pMinusScale = new Vector3(-1, 1, 1);
        dashWfs = new WaitForSeconds(dashCooltime);
        invisibleWfs = new WaitForSeconds(invisibleTime);
        canDash = true;
    }

    private void OnEnable()
    {
        inputs.onMovementChanged += PlayerMovement;
        inputs.onMouseDirectionChanged += FaceMouseDir;
    }

    private void OnDestroy()
    {
        inputs.onMovementChanged -= PlayerMovement;
        inputs.onMouseDirectionChanged -= FaceMouseDir;
    }

    private void Update()
    {
        PlayerDash();
    }

    private void PlayerMovement(Vector2 direction)
    {
        myRigid.velocity = direction * playerMoveSpeed;
    }

    private void FaceMouseDir(Vector3 mouseDir)
    {
        Vector3 resultDir = Vector3.Cross(Vector3.up, mouseDir);
        if(resultDir.z < 0)
        {
            transform.localScale = Vector3.one;
        }
        else if(resultDir.z > 0)
        {
            transform.localScale = pMinusScale;
        }
    }

    private void PlayerDash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (canDash)
            {
                canDash = false;
                myCol.enabled = false;
                StartCoroutine("CanDashRoutine");
                StartCoroutine("InvisibleTimeRoutine");
                myRigid.DOMove(transform.position + inputs.mouseDirection
                    * dashSpeed, 0.3f);
            }
        }      
    }

    IEnumerator CanDashRoutine()
    {
        yield return dashWfs;
        canDash = true;
    }
    IEnumerator InvisibleTimeRoutine()
    {
        yield return invisibleWfs;
        myCol.enabled = true;
    }
}
