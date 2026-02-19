using UnityEngine;
using Unity.Collections;
using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMoving : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    Animator animator;
    float speed = 2f;
    Vector2 motionVector;
    private Vector2 lastDirection = Vector2.down;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    private void Update()
    {
        float horizontal =
            Keyboard.current.aKey.isPressed ? -1 :
            Keyboard.current.dKey.isPressed ? 1 : 0;

        float vertical =
            Keyboard.current.sKey.isPressed ? -1 :
            Keyboard.current.wKey.isPressed ? 1 : 0;

        motionVector = new Vector2(horizontal, vertical);

        if (motionVector.sqrMagnitude > 0.01f)
        {
            lastDirection = motionVector;
        }


        animator.SetFloat("MoveX", motionVector.sqrMagnitude > 0.01f ? motionVector.x : lastDirection.x);
        animator.SetFloat("MoveY", motionVector.sqrMagnitude > 0.01f ? motionVector.y : lastDirection.y);

        animator.SetBool("isMoving", motionVector.sqrMagnitude > 0.01f);

    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody2d.linearVelocity = motionVector*speed;
    }
}
