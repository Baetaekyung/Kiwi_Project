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
    [SerializeField] private float dashIvitime;

    Vector3 pMinusScale;
    public bool canDash;
    private WaitForSeconds dashWfs;
    private WaitForSeconds dashIvi;

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
        dashIvi = new WaitForSeconds(dashIvitime);
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
                GameManager.Instance.isInvisible = 1;
                StartCoroutine("CanDashRoutine");
                StartCoroutine("DashIvisibleRoutine");
                myRigid.DOMove(transform.position + inputs.moveDirection
                    * dashSpeed, 0.3f);
            }
        }      
    }

    IEnumerator CanDashRoutine()
    {
        yield return dashWfs;
        canDash = true;
    }
    IEnumerator DashIvisibleRoutine()
    {
        yield return dashIvi;
        GameManager.Instance.isInvisible = 0;
    }
}
