using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;

    [SerializeField] Animator animator;

    float moveX;
    float moveY;

    void Update()
    {

        moveX = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
        moveY = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;

        transform.Translate(moveX, moveY, 0f);

        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY", moveY);

        if (Input.GetAxisRaw("Horizontal") == 1 ||
            Input.GetAxisRaw("Horizontal") == -1 ||
            Input.GetAxisRaw("Vertical") == 1 ||
            Input.GetAxisRaw("Vertical") == -1)
        {
            animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
        
}
