using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 10;
    [Header("Weapon Manager")]
    public int currentWep;
    public bool hasWeapon1, hasWeapon2;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) { Cursor.lockState = CursorLockMode.None; }
        Movement();
        WeaponManager();
    }
    private void Movement()
    {
        float translation = Input.GetAxis("Vertical") * movementSpeed;
        float straffe = Input.GetAxis("Horizontal") * movementSpeed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, 0, translation);
    }


    void WeaponManager()
    {

        //Changing Weapon
        if (currentWep >= 3)
        {
            currentWep = 1;
        }
        else if (currentWep <= 0)
        {
            currentWep = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) { currentWep = 1; };
        if (Input.GetKeyDown(KeyCode.Alpha2)) { currentWep = 2; };
    }
}
