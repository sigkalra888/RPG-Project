using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private float vertical, horizontal = 0;
    private float moveSpeed, jumpSpeed;

    [SerializeField]
    private float maxJumpSpeed;
    
    [SerializeField]
    private float gravity, accelerration, decay, maxMoveSpeed = 0;

    [SerializeField]
    private bool isDush, isJump = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) { isDush = true; }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) { isDush = false; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isJump) { return; }
            isJump = true;
            jumpSpeed = maxJumpSpeed;
        }

        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        if(vertical != 0 || horizontal != 0)
        {
            if (moveSpeed < maxMoveSpeed)
            {
                moveSpeed += accelerration;
            }
        }
        else
        {
            if (moveSpeed > 0)
            {
                moveSpeed -= accelerration * 1.2f;
            }
            else if (moveSpeed < 0) { moveSpeed = 0; }
        }
    }

    private void FixedUpdate()
    {
        JumpAction();
        MoveAction();
    }
    /// <summary>
    /// 移動処理
    /// </summary>
    public void MoveAction()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1));
        Vector3 moveForward = cameraForward * vertical + Camera.main.transform.right * horizontal;
        
        transform.position += isDush != false ? (moveForward * moveSpeed) * 2f : moveForward * moveSpeed;

        if(transform.position.y > 0) { transform.position -= new Vector3(0, gravity, 0); }
        else if(transform.position.y <= 0) { transform.position = new Vector3(transform.position.x, 0, transform.position.z); }

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

    private void JumpAction()
    {
        if (!isJump) { return; }
        transform.position += new Vector3(0, jumpSpeed, 0);
        jumpSpeed *= decay;
        if(jumpSpeed < 0.01 || transform.position.y <= 0) { isJump = false; }
    }
}
