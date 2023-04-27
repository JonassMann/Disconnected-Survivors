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

    public bool onPC;

    public bool facingRight = true;

    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        joystick = GameObject.Find("Joystick").GetComponent<VariableJoystick>();
        moveInput = new Vector2();

        if(onPC)
            joystick.gameObject.SetActive(false);

        if (PlayerPrefs.HasKey("useGrav"))
        {
            if (useGrav && PlayerPrefs.GetInt("useGrav") == 0)
                DisableGrav();
            else if (!useGrav && PlayerPrefs.GetInt("useGrav") == 1)
                EnableGrav();
        }
    }

    private void Update()
    {
        if (onPC)
        {
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized ;
        }
        else if (!useGrav)
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
            PlayerPrefs.SetInt("useGrav", 1);
        }
    }

    public void DisableGrav()
    {
        if (!useGrav) return;

        InputSystem.DisableDevice(GravitySensor.current);
        joystick.gameObject.SetActive(true);
        useGrav = false;
        PlayerPrefs.SetInt("useGrav", 0);
    }

    public void DoMove(float speed)
    {
        rb.velocity = moveInput * speed;
    }
}
