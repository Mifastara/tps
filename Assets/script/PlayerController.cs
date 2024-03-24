using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _fallVelocity = 0;
    public float gravity = 9.8f;
    private CharacterController _characterController;
    public float jampForce;
    public float speed;
    private Vector3 _moveVector;
    public Animator animator;
    
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelocity = -jampForce;
        }
    }

    private void Movement()
    {
        _moveVector = Vector3.zero;
        var run = 0;
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            run = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            run = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            run = 4;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            run = 3;
        }
        animator.SetInteger("run", run);
    }

    void FixedUpdate()
    {
        _characterController.Move(_moveVector * speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
