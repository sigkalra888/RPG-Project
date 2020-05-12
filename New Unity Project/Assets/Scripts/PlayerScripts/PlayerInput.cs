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
            isJump = true;
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
        MoveAction();
    }
    /// <summary>
    /// 移動処理
    /// </summary>
    public void MoveAction()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1));
        Vector3 moveForward = cameraForward * vertical + Camera.main.transform.right * horizontal;
        
        transform.position += isDush != false ? (moveForward * moveSpeed) * 2f + new Vector3(0, jumpSpeed, 0) : moveForward * moveSpeed + new Vector3(0, jumpSpeed, 0);

        if (isJump && jumpSpeed < maxJumpSpeed) { jumpSpeed += accelerration; }
        else if (isJump && jumpSpeed > maxJumpSpeed) { isJump = false; }
        Debug.Log(jumpSpeed);

        if(!isJump && transform.position.y > 0) { transform.position -= new Vector3(0, gravity, 0); }

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
}
