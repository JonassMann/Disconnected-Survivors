using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public SpriteRenderer playerSprite;

    private Rigidbody2D rb;
    [SerializeField] private VariableJoystick joystick;

    [SerializeField] private Vector2 moveInput;
    public bool useGrav = false;

    public bool facingRight = true;

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        joystick = GameObject.Find("Joystick").GetComponent<VariableJoystick>();
        moveInput = new Vector2();
    }

    private void Update()
    {
        if (!useGrav)
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        else
        {
            moveInput = GravitySensor.current.gravity.ReadValue() * 3;
        }

        if ((facingRight && moveInput.x < 0) || (!facingRight && moveInput.x > 0))
        {
            facingRight = !facingRight;
            playerSprite.flipX = !facingRight;
        }
    }

    public void EnableGrav()
    {
        if (useGrav) return;

        if (SystemInfo.supportsGyroscope)
        {
            InputSystem.EnableDevice(GravitySensor.current);
            joystick.gameObject.SetActive(false);
            useGrav = true;
        }
    }

    public void DisableGrav()
    {
        if (!useGrav) return;

        InputSystem.DisableDevice(GravitySensor.current);
        joystick.gameObject.SetActive(true);
        useGrav = false;
    }

    public void DoMove(float speed)
    {
        rb.velocity = moveInput * speed;
    }
}
