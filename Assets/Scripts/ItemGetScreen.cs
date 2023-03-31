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

    private int levelCount;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        randomizedItems = new List<GameObject>();
    }

    public void OpenItemScreen(int items, int maxCount = 3)
    {
        if (itemList.Count <= 0) return;

        itemScreen.SetActive(true);
        joyStick.SetActive(false);
        Time.timeScale = 0;

        RollItem(maxCount);
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
    }

    public void SelectItem(int val)
    {
        if (val >= randomizedItems.Count) return;

        player.GetComponent<PlayerController>().AddWeapon(randomizedItems[val].GetComponent<Weapon>().itemName, randomizedItems[val]);

        if(levelCount > 0)
        {
            levelCount--;
            return;
        }
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
        Time.timeScale = 1f;
        itemScreen.SetActive(false);
        joyStick.SetActive(true);
    }

    public void RemoveItem(GameObject item)
    {
        if (itemList.Contains(item))
            itemList.Remove(item);
    }
}
