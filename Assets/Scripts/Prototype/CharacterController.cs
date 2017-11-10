using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Movement")]
    public float movementSpeed = 10;
    [Header("Weapon Manager")]
    public int currentWep;
    public bool hasWeapon1, hasWeapon2,switchingWeapon,gotWeapon;
    public GameObject currentWeapon1, currentWeapon2, CurrentWeaponLocation, PutAwayWeaponLocation, PutAwayWeaponLocation2;
    public int weapon1MaxAmmo, weapon2MaxAmmo, weapon1CurrentAmmo, weapon2CurrentAmmo;
    public GameObject bulletPref;
    public Transform bulletSpawn,playerTra;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) { Cursor.lockState = CursorLockMode.None; }
        Movement();
        StartCoroutine("WeaponManager");
    }
    private void Movement()
    {
        float translation = Input.GetAxis("Vertical") * movementSpeed;
        float straffe = Input.GetAxis("Horizontal") * movementSpeed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        transform.Translate(straffe, 0, translation);
    }


    IEnumerator WeaponManager()
    {
        
        #region Switching Weapons
        if (currentWep == 1 && !gotWeapon && !switchingWeapon)
        {
            //Switching from weapon 2 to 1
            currentWeapon1.transform.parent = CurrentWeaponLocation.transform;
            currentWeapon1.transform.localPosition = new Vector3(0, 0, 0);
            currentWeapon1.transform.localRotation = Quaternion.AngleAxis(0, Vector3.forward);

            currentWeapon2.transform.parent = PutAwayWeaponLocation.transform;
            currentWeapon2.transform.localPosition = new Vector3(0, 0, 0);
            currentWeapon2.transform.localRotation = Quaternion.AngleAxis(0, Vector3.forward);
            gotWeapon = true;
        }
        else if (currentWep == 2 && !gotWeapon && !switchingWeapon)
        {
            //Switching from weapon 1 to 2
            currentWeapon2.transform.parent = CurrentWeaponLocation.transform;
            currentWeapon2.transform.localPosition = new Vector3(0, 0, 0);
            currentWeapon2.transform.localRotation = Quaternion.AngleAxis(0, Vector3.forward);

            currentWeapon1.transform.parent = PutAwayWeaponLocation.transform;
            currentWeapon1.transform.localPosition = new Vector3(0, 0, 0);
            currentWeapon1.transform.localRotation = Quaternion.AngleAxis(0, Vector3.forward);
            gotWeapon = true;
        }
        #endregion

        #region Checking for users input to keys
        if (currentWep >= 3)
        {
            currentWep = 1;
        }
        else if (currentWep <= 0)
        {
            currentWep = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWep = 1;
            gotWeapon = false;
        };
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWep = 2;
            gotWeapon = false;
        };
        #endregion


        #region Weapon Shooting
        if (Input.GetMouseButton(0) && gotWeapon && currentWep == 1)
        {
            GameObject currentBul = Instantiate(bulletPref);
            currentBul.transform.position = bulletSpawn.position;
            currentBul.transform.parent = bulletSpawn;
            currentBul.transform.localRotation = Quaternion.Euler(-90, 0, 0);
            currentBul.transform.parent = null;
            currentBul.transform.localScale = new Vector3(0.1668645f, 0.1668645f, 0.1668645f);
            yield return null;
        }
        else if (Input.GetMouseButtonDown(0) && gotWeapon && currentWep == 2)
        {
            GameObject currentBul = Instantiate(bulletPref);
            currentBul.transform.position = bulletSpawn.position;
            currentBul.transform.rotation = Quaternion.Euler(playerTra.rotation.x, playerTra.rotation.y, playerTra.rotation.z + 90);
        }
        #endregion
        #region Weapon Reloading
        if (Input.GetKeyDown(KeyCode.R) && gotWeapon)
        {
            if (currentWep == 1)
            {
                weapon1CurrentAmmo = weapon1MaxAmmo;
            }
            else
            {
                weapon2CurrentAmmo = weapon2MaxAmmo;
            }
        }
        #endregion

    }
}
