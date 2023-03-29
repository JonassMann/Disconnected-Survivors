using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemGetScreen : MonoBehaviour
{
    private GameObject player;

    public GameObject itemScreen;
    public GameObject joyStick;

    public List<GameObject> buttons;

    public List<GameObject> itemList;
    private List<GameObject> randomizedItems;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        randomizedItems = new List<GameObject>();
    }

    private void RollItem(int maxCount)
    {
        for (int i = 0; i < buttons.Count; i++) buttons[i].SetActive(false);

        randomizedItems.Clear();
        randomizedItems.AddRange(itemList);

        for(int i = randomizedItems.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = randomizedItems[i];
            randomizedItems[i] = randomizedItems[j];
            randomizedItems[j] = temp;
        }

        for (int i = 0; i < maxCount && i < randomizedItems.Count; i++)
            SetItem(buttons[i], randomizedItems[i]);

        itemScreen.SetActive(true);
        joyStick.SetActive(false);
    }

    public void SelectItem(int val)
    {


        CloseItemScreen();
    }

    private void SetItem(GameObject button, GameObject weapon)
    {
        button.SetActive(true);
        button.GetComponentInChildren<Image>().sprite = weapon.GetComponent<Weapon>().itemImg;
        button.GetComponentInChildren<TMP_Text>().text = weapon.GetComponent<Weapon>().itemName;
    }

    private void CloseItemScreen()
    {
        itemScreen.SetActive(false);
        joyStick.SetActive(true);
    }
}
