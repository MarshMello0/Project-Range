using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Recoil Settings")]
    public float recoilWep1;
    public float recoilWep2;
    [Header("Movement")]
    public float movementSpeed = 10;
    public float jumpHeight;
    public Rigidbody playerRB;
    public bool isGrounded;
    [Header("Weapon Manager")]
    public int currentWep;
    public bool hasWeapon1, hasWeapon2,switchingWeapon,gotWeapon,canFire;
    public GameObject currentWeapon1, currentWeapon2, CurrentWeaponLocation, PutAwayWeaponLocation, PutAwayWeaponLocation2;
    public int weapon1MaxAmmo, weapon2MaxAmmo, weapon1CurrentAmmo, weapon2CurrentAmmo;
    public GameObject bulletPref;
    public Transform bulletSpawn1,bulletSpawn2,playerTra;
    [Header("Scripts")]
    public CameraMovement camMov;
    public UserSettings settings;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        settings = GameObject.Find("DDOL").GetComponent<UserSettings>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.F1) && Cursor.lockState == CursorLockMode.None) { Cursor.lockState = CursorLockMode.Locked; }
        if (Input.GetKey(KeyCode.F2) && Cursor.lockState == CursorLockMode.Locked) { Cursor.lockState = CursorLockMode.None; }
        Movement();
        StartCoroutine("WeaponManager");
        Debug.DrawRay(Camera.main.transform.position, , Color.red);
        if (Input.GetKeyDown(settings.cInteract))
        {
            RaycastHit hit;
            
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
            {
                print(hit.transform.name);
            }
        }
    }
    private void Movement()
    {
        float translation = 0;
        float straffe = 0;
        float jump = 0;
        if (Input.GetKey(settings.cForwards))
        {
            translation = 1 * movementSpeed;
            
        }
        else if (Input.GetKey(settings.cBackwards))
        {
            translation = -1 * movementSpeed;
        }
        if (Input.GetKey(settings.cRight))
        {
            straffe = 1 * movementSpeed;
        }
        else if (Input.GetKey(settings.cLeft))
        {
            straffe = -1 * movementSpeed;
        }
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;
        
        if (Input.GetKeyDown(settings.cJump) && isGrounded)
        {
            jump = 1 * jumpHeight;
            playerRB.AddRelativeForce(new Vector3(playerRB.velocity.x, jump, playerRB.velocity.z),ForceMode.VelocityChange);
            isGrounded = false;
        }
        
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
        if (Input.GetMouseButton(0) && gotWeapon && currentWep == 1 && weapon1CurrentAmmo > 0 && canFire)
        {
            GameObject currentBul = Instantiate(bulletPref);
            currentBul.transform.position = bulletSpawn1.position;
            currentBul.transform.parent = bulletSpawn1;
            currentBul.transform.localRotation = Quaternion.Euler(180, 0, 0);
            currentBul.transform.parent = null;
            currentBul.transform.localScale = new Vector3(0.1668645f, 0.1668645f, 0.1668645f);

            weapon1CurrentAmmo--;
            camMov.mouseLook = new Vector2(camMov.mouseLook.x, camMov.mouseLook.y + recoilWep1);
            canFire = false;
            yield return new WaitForSeconds(0.1f);
            canFire = true;
        }
        else if (Input.GetMouseButtonDown(0) && gotWeapon && currentWep == 2 && canFire && weapon2CurrentAmmo > 0)
        {
            GameObject currentBul = Instantiate(bulletPref);
            currentBul.transform.position = bulletSpawn2.position;
            currentBul.transform.parent = bulletSpawn2;
            currentBul.transform.localRotation = Quaternion.Euler(180, 0, 0);
            currentBul.transform.parent = null;
            currentBul.transform.localScale = new Vector3(0.1668645f, 0.1668645f, 0.1668645f);
            weapon2CurrentAmmo--;
            camMov.mouseLook = new Vector2(camMov.mouseLook.x, camMov.mouseLook.y + recoilWep2);
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

    void OnCollisionStay(Collision col)
    {
        isGrounded = true;
    }
}
