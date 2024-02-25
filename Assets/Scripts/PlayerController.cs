using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float gravity = 9.8f;
    public float Speed;
    public float jumpForce;

    private Vector3 _move;
    private float _fallVelocity = 0;

    CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        _move = Vector3.zero;
        if (Input.GetKey(KeyCode.W)){
            _move += transform.forward;
        }
        
        if (Input.GetKey(KeyCode.S)){
            _move -= transform.forward;
        }
            
        if (Input.GetKey(KeyCode.D)){
            _move += transform.right;
        }
        if (Input.GetKey(KeyCode.A)) {
            _move -= transform.right;
        }
        if (_move != Vector3.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
        //_controller.Move(_move * Speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Space) && _controller.isGrounded)
        {
            _fallVelocity = -jumpForce;
            animator.SetBool("isGrounded", false);
        }
         
    }
     void FixedUpdate()
    {
        _controller.Move(_move * Speed * Time.fixedDeltaTime);

        _fallVelocity += gravity * Time.fixedDeltaTime;
        _controller.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);

        if (_controller.isGrounded)
        {
            _fallVelocity = 0;
            animator.SetBool("isGrounded", true);
        }
    }
}
