using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGetScreen : MonoBehaviour
{
    private GameObject player;

    public GameObject itemScreen;
    public GameObject joyStick;

    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public List<GameObject> itemList;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void RollItem()
    {
        itemScreen.SetActive(true);
        joyStick.SetActive(false);
    }

    private void CloseItemScreen()
    {
        itemScreen.SetActive(false);
        joyStick.SetActive(true);
    }
}
