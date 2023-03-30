using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private ItemGetScreen itemGetScreen;

    public GameObject startWeapon;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float exp = 0;
    public int level = 1;
    public float showExp = 0;

    private Dictionary<string, Weapon> weapons;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        itemGetScreen = GameObject.FindGameObjectWithTag("GameController").GetComponent<ItemGetScreen>();
        weapons = new Dictionary<string, Weapon>();

        if(startWeapon != null)
        {
            AddWeapon(startWeapon.GetComponent<Weapon>().itemName, startWeapon);
        }
    }

    void Update()
    {
        playerMovement.DoMove(moveSpeed);

        // Run weapon stuff, WeaponStats parameter
    }

    public void AddWeapon(string weaponName, GameObject weapon)
    {
        if (weapons.ContainsKey(weaponName))
            weapons[weaponName].LevelUp();
        else
        {
            weapons[weaponName] = GameObject.Instantiate(weapon, transform).GetComponent<Weapon>();
        }
    }

    [Button]
    public void AddExp(float addExp)
    {
        exp += addExp;
        showExp += addExp;

        int levelsForItems = 0;

        while (showExp >= PlayerTools.GetNextExp(level))
        {
            showExp -= PlayerTools.GetNextExp(level);
            level++;
            levelsForItems++;
        }

        if (levelsForItems <= 0) return;
        itemGetScreen.OpenItemScreen(levelsForItems);
    }
}
