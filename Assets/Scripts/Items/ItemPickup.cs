using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    private GameObject itemScreen;

    private void Start()
    {
        itemScreen = GameObject.FindGameObjectWithTag("GameController");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
