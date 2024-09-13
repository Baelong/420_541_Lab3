using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunComponent : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float chargeSpeed = 10f;
    private float chargeTime = 0f;
    public float baseBulletSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*•	You need to detect when the player starts holding 
        the fire button. Use Input.GetButtonDown("Fire1") to detect 
        when the button is initially pressed.
        */
        if (Input.GetButtonDown("Fire1"))
        {
            chargeTime = 0f; 
        }

        /*We will now make the fire button be held down to update the charge time.
          Use an Input.GetButton("Fire1") to Monitor the fire1 Button is held down 
          continue increasing the charge time.
        */
          if (Input.GetButton("Fire1"))
        {
            //Increase charge time and and apply limit to charging time 
            chargeTime += Time.deltaTime;
            chargeTime = Mathf.Clamp(chargeTime, 0, 3);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            // Spawn bullet when Fire1 is released
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            /*
            Access the bullet component to change it’s speed according to your  chargetime 
            You can access an object component with this line of code :  BulletComponent bulletComp = bullet.GetComponent<BulletComponent>();
            bullet.bulletSpeed = chargeTime * baseBulletSpeed;
            */
            BulletComponent bulletComp = bullet.GetComponent<BulletComponent>();
            bulletComp.bulletSpeed = chargeTime * baseBulletSpeed;

        }
    }

}

