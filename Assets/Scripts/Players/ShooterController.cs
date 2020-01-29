using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    [SerializeField] SO_Shooter shooter;

    [SerializeField] float shootDelay;

    [SerializeField] PlayerController player;

    bool isFireing = false;

    bool lookingRight = true;

    [SerializeField] Transform bulletSpawnPoint;
    float currentDelay = 0.0f;

    
    

    void Update()
    {
        if (currentDelay > 0)
        {
            currentDelay -= Time.deltaTime * shootDelay;
        }


        if (Input.GetButtonDown("Fire1"))
        {
            isFireing = true;
        }

        if (Input.GetButton("Fire1"))
        {
            if (currentDelay <= 0)
            {
                Fire(transform, bulletSpawnPoint);
                currentDelay = shooter.Delay;
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isFireing = false;
        }
    }
    

    public void Fire(Transform transform, Transform bulletSpawnPoint)
    {
        if (Time.timeScale > 0)
        {
            for (int i = 0; i < shooter.Numb; i++)
                    {
                        GameObject laserGreen = Instantiate(shooter.PrefablaserGreen, bulletSpawnPoint);
                        laserGreen.transform.parent = null;
                        laserGreen.transform.localScale = Vector3.one;
            
                        laserGreen.transform.position += (Vector3)Random.insideUnitCircle * shooter.Dispertion;
            
                        laserGreen.GetComponent<Rigidbody2D>().velocity = transform.right * shooter.BulletSpeed;
                    }
        }
        
    }
}
