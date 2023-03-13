using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;

    [SerializeField] private float moveSpeed;

    // List gameobject weapons

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        playerMovement.DoMove(moveSpeed);

        // Run weapon stuff, WeaponStats parameter
    }
}
