using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private VariableJoystick joystick;

    [SerializeField] private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        joystick = GameObject.Find("Joystick").GetComponent<VariableJoystick>();
        moveInput = new Vector2();
    }

    private void Update()
    {
        moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
    }

    public void DoMove(float speed)
    {
        rb.velocity = moveInput * speed;
    }
}
