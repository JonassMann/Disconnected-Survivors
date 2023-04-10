using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private VariableJoystick joystick;

    [SerializeField] private Vector2 moveInput;
    public bool useGrav = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystick = GameObject.Find("Joystick").GetComponent<VariableJoystick>();
        moveInput = new Vector2();

        EnableGrav();
    }

    private void Update()
    {
        if (!useGrav)
            moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        else
        {
            moveInput = GravitySensor.current.gravity.ReadValue();
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
        rb.velocity = moveInput * speed * 5;
    }
}
