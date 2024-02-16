using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private InputReader _ir = null;
    private Rigidbody2D _rb = null;
    [SerializeField] public float chargeSpeedMultiplier = 1f;
    [SerializeField] public float maxCharge = 10f;
    private float chargeTimer = 0f;

    public bool isCharging = false;
    public bool grounded = true;
    void Awake()
    {
        _ir = GetComponent<InputReader>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!isCharging && _ir.Jump && grounded) {
            isCharging = true;
        } else if (isCharging && _ir.Jump) {
            if (chargeTimer < maxCharge) {
                chargeTimer += 0.5f * chargeSpeedMultiplier;
            }
            
            Debug.Log("charge " + chargeTimer);
        } else if (isCharging && !_ir.Jump) {
            Debug.Log("release charge " + chargeTimer);
            _rb.AddForce(transform.up * chargeTimer, ForceMode2D.Impulse);
            isCharging = false;
            chargeTimer = 0;
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
