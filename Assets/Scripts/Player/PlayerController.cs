using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;

    [SerializeField] private float moveSpeed;

    [SerializeField] private float exp = 0;
    public int level = 1;
    public float showExp = 0;

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

    public void AddWeapon()
    {

    }

    [Button]
    public void AddExp(float addExp)
    {
        exp += addExp;
        showExp += addExp;

        while (showExp >= PlayerTools.GetNextExp(level))
        {
            showExp -= PlayerTools.GetNextExp(level);
            level++;
        }
    }
}
