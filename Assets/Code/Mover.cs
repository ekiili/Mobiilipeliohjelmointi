using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private InputReader _ir = null;
    private Rigidbody2D _rb = null;
    [SerializeField] public float speed = 5f;
    [SerializeField] public float jumpSpeed = 5f;

    public bool grounded = true;
    void Awake()
    {
        _ir = GetComponent<InputReader>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _rb.AddForce(_ir.Move * speed, ForceMode2D.Force);

        bool jumpAllowed = _ir.Jump && grounded;

        if (jumpAllowed) {
            jumpAllowed = false;
            _rb.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
            Debug.Log("Jump!");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        grounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}