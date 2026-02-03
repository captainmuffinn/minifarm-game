using UnityEngine;
using Unity.Collections;
using System.Collections.Generic;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMoving : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float speed = 2f;
    Vector2 motionVector;
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        motionVector = new Vector2(
            Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertikal")
            );
    }

    void Fixedupdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody2d.linearVelocity = motionVector*speed;
    }
}
