using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private ItemGetScreen itemGetScreen;

    public GameObject startWeapon;

    public PlayerStats playerStats;
    public WeaponStatBlock weaponStats;

    public float IFrameTime;
    private float IFrameTimer = 0;
    private float health;

    [SerializeField] private float exp = 0;
    public int level = 1;
    public float showExp = 0;

    private Dictionary<string, Weapon> weapons;

    private void Awake()
    {
        health = playerStats.maxHealth;
        playerMovement = GetComponent<PlayerMovement>();
        itemGetScreen = GameObject.FindGameObjectWithTag("GameController").GetComponent<ItemGetScreen>();
        weapons = new Dictionary<string, Weapon>();
    }

    private void Start()
    {
        // Read and add player stats

        if (startWeapon != null)
        {
            AddWeapon(startWeapon.GetComponent<Weapon>().itemName, startWeapon);
        }
        AddExp(0);
    }

    void Update()
    {
        playerMovement.DoMove(playerStats.moveSpeed);
        if (IFrameTimer > 0) IFrameTimer -= Time.deltaTime;

        // Add regen
        // Run weapon stuff, WeaponStats parameter
    }

    public void AddWeapon(string weaponName, GameObject weapon)
    {
        if (weapons.ContainsKey(weaponName))
        {
            GameObject temp = weapons[weaponName].LevelUp(gameObject);
            if (temp == null) return;

            if (temp != gameObject) itemGetScreen.AddItem(temp);
            itemGetScreen.RemoveItem(weapon);
        }
        else if (weapon.GetComponent<Weapon>().childWeapon != "")
        {
            weapons[weaponName] = Instantiate(weapon, transform).GetComponent<Weapon>();
            Destroy(weapons[weapons[weaponName].childWeapon].gameObject);
            weapons.Remove(weapons[weaponName].childWeapon);
        }
        else
        {
            weapons[weaponName] = Instantiate(weapon, transform).GetComponent<Weapon>();
        }
    }

    [Button]
    public void AddExp(float addExp)
    {
        addExp *= playerStats.expMult;

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

    public void TakeDamage(float damage)
    {
        if (IFrameTimer > 0) return;

        IFrameTimer = IFrameTime;

        health -= damage - playerStats.armor;

        if (health <= 0)
        {
            Debug.Log("Ded");
        }
    }
}
