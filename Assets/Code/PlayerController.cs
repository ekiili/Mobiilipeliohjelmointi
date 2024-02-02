using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public InputAction PlayerControls;

    Vector2 moveDirection = Vector2.zero;

    private void OnEnable()
    {
        PlayerControls.Enable();
    }
    
    private void OnDisable()
    {
        PlayerControls.Disable();
    }

    void Update()
    {
        //moveDirection.x = Input.GetAxis("Horizontal");
        //moveDirection.y = Input.GetAxis("Vertical");

        moveDirection = PlayerControls.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }
}

